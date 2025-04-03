using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using denizen_generator_parser.Models;
using denizen_generator_parser.Services;

namespace denizen_generator_parser.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DenizenController : ControllerBase
    {
        private readonly HttpClient _client;
        private readonly IDenizenService _denizenService;
        private readonly ILogger<DenizenController> _logger;

        public DenizenController(
            IDenizenService denizenService,
            ILogger<DenizenController> logger)
        {
            _client = new HttpClient();
            _denizenService = denizenService;
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

                var (personsList, totalLost, attempts, isServiceDown) = await _denizenService.GeneratePersonsData(request);
                string status = isServiceDown ? "service_down" : personsList.Count() == request.Quantity ? "success" : "incomplete";

                // Save monitoring data
                var monitoring = new DenizenGeneratorMonitoring
                {
                    Id = Guid.NewGuid().ToString(),
                    Quantity = request.Quantity.ToString(),
                    StartYear = request.StartYear.ToString(),
                    EndYear = request.EndYear.ToString(),
                    Inserted = personsList.Count().ToString(),
                    Loss = totalLost.ToString(),
                    Timestamps = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Status = status
                };

                // Hanya proses jika berhasil dapat semua data atau service down
                if (personsList.Count() == request.Quantity || isServiceDown)
                {
                    await _denizenService.SaveMonitoringData(monitoring);

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
                        total_inserted = personsList.Count(),
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
                var monitoring = await _denizenService.GetMonitoringData();
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
