using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using denizen_generator_parser.Models;
using denizen_generator_parser.Data;
using Microsoft.EntityFrameworkCore;

namespace denizen_generator_parser.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DenizenController : ControllerBase
    {
        private readonly HttpClient _client;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DenizenController> _logger;

        public DenizenController(ApplicationDbContext context, ILogger<DenizenController> logger)
        {
            _client = new HttpClient();
            _context = context;
            _logger = logger;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateData([FromBody] GenerateRequest request)
        {
            try
            {
                if (request.Quantity <= 0)
                    return BadRequest("Quantity must be greater than 0");

                if (request.EndYear < request.StartYear)
                    return BadRequest("End year must be greater than or equal to start year");

                var personsList = new HashSet<object>();
                int totalLost = 0;
                int attempts = 0;
                bool isServiceDown = false;

                string baseUrl = $"https://fakerapi.it/api/v2/persons?_birthday_start={request.StartYear}-01-01&_birthday_end={request.EndYear}-12-31";

                // Terus mencoba sampai dapat jumlah data yang tepat atau service down
                while (personsList.Count < request.Quantity && !isServiceDown)
                {
                    int needed = request.Quantity - personsList.Count;
                    // Request lebih untuk mengantisipasi data tidak valid
                    int requestQuantity = Math.Min(needed * 2, 100); // Max 100 per request untuk menghindari overload
                    string url = $"{baseUrl}&_quantity={requestQuantity}";

                    try
                    {
                        string response = await _client.GetStringAsync(url);
                        var jsonDocument = JsonDocument.Parse(response);

                        if (jsonDocument.RootElement.TryGetProperty("data", out JsonElement data))
                        {
                            foreach (var person in data.EnumerateArray())
                            {
                                if (!person.TryGetProperty("gender", out JsonElement genderElement))
                                {
                                    totalLost++;
                                    continue;
                                }

                                string gender = genderElement.GetString()?.ToLower() ?? string.Empty;
                                if (gender == "male" || gender == "female")
                                {
                                    personsList.Add(new
                                    {
                                        first_name = person.GetProperty("firstname").GetString(),
                                        last_name = person.GetProperty("lastname").GetString(),
                                        birth_date = person.GetProperty("birthday").GetString(),
                                        gender = gender
                                    });

                                    if (personsList.Count >= request.Quantity) break;
                                }
                                else
                                {
                                    totalLost++;
                                }
                            }
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        _logger.LogError(ex, "Service is down or connection issue");
                        isServiceDown = true;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error fetching data from API");
                        await Task.Delay(1000); // Tunggu sebentar sebelum retry
                    }

                    attempts++;
                }

                var status = isServiceDown ? "failed" : "success";
                
                // Save monitoring data
                var monitoring = new DenizenGeneratorMonitoring
                {
                    Id = Guid.NewGuid().ToString(),
                    Quantity = request.Quantity.ToString(),
                    StartYear = request.StartYear.ToString(),
                    EndYear = request.EndYear.ToString(),
                    Inserted = personsList.Count.ToString(),
                    Loss = totalLost.ToString(),
                    Timestamps = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Status = status
                };

                // Hanya proses jika berhasil dapat semua data atau service down
                if (personsList.Count == request.Quantity || isServiceDown)
                {
                    // Simpan ke database
                    _context.DenizenGeneratorMonitorings.Add(monitoring);
                    await _context.SaveChangesAsync();

                    if (!isServiceDown)
                    {
                        // Kirim data ke endpoint lain jika berhasil
                        string jsonResult = JsonSerializer.Serialize(personsList, new JsonSerializerOptions { WriteIndented = true });
                        var content = new StringContent(jsonResult, Encoding.UTF8, "application/json");
                        var postResponse = await _client.PostAsync("http://localhost:47001/denizen", content);
                        
                        if (!postResponse.IsSuccessStatusCode)
                        {
                            _logger.LogError($"Failed to send data to external API. Status code: {postResponse.StatusCode}");
                            return StatusCode(500, "Failed to send data to external API");
                        }
                    }
                }

                return Ok(new
                {
                    status,
                    monitoring = new
                    {
                        total_inserted = personsList.Count,
                        total_lost = totalLost,
                        attempts = attempts,
                        is_service_down = isServiceDown
                    },
                    data = status == "success" ? personsList : null
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing request");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("monitoring")]
        public async Task<IActionResult> GetMonitoring()
        {
            try
            {
                var monitoring = await _context.DenizenGeneratorMonitorings
                    .OrderByDescending(m => m.Timestamps)
                    .ToListAsync();

                return Ok(monitoring);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching monitoring data");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
