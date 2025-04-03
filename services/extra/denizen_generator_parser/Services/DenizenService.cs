using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using denizen_generator_parser.Data;
using denizen_generator_parser.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace denizen_generator_parser.Services
{
    public class DenizenService : IDenizenService
    {
        private readonly HttpClient _client;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DenizenService> _logger;
        private readonly IBloodTypeService _bloodTypeService;
        private readonly IEyeColorService _eyeColorService;

        public DenizenService(
            ApplicationDbContext context,
            ILogger<DenizenService> logger,
            IBloodTypeService bloodTypeService,
            IEyeColorService eyeColorService)
        {
            _client = new HttpClient();
            _context = context;
            _logger = logger;
            _bloodTypeService = bloodTypeService;
            _eyeColorService = eyeColorService;
        }

        public async Task<(IEnumerable<object> Data, int TotalLost, int Attempts, bool IsServiceDown)> GeneratePersonsData(GenerateRequest request)
        {
            var personsList = new HashSet<object>();
            int totalLost = 0;
            int attempts = 0;
            bool isServiceDown = false;

            string baseUrl = $"https://fakerapi.it/api/v2/persons?_birthday_start={request.StartYear}-01-01&_birthday_end={request.EndYear}-12-31";

            while (personsList.Count < request.Quantity && !isServiceDown)
            {
                int needed = request.Quantity - personsList.Count;
                int requestQuantity = Math.Min(needed * 2, 100);
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
                                string? bloodType = person.TryGetProperty("blood_type", out JsonElement bloodTypeElement) 
                                    ? bloodTypeElement.GetString() 
                                    : _bloodTypeService.GenerateBloodType();

                                string? eyeColor = person.TryGetProperty("eye_color", out JsonElement eyeColorElement)
                                    ? eyeColorElement.GetString()
                                    : _eyeColorService.GenerateEyeColor();

                                personsList.Add(new
                                {
                                    first_name = person.GetProperty("firstname").GetString(),
                                    last_name = person.GetProperty("lastname").GetString(),
                                    birth_date = person.GetProperty("birthday").GetString(),
                                    gender = gender,
                                    blood_type = bloodType,
                                    eye_color = eyeColor
                                });

                                if (personsList.Count >= request.Quantity)
                                    break;
                            }
                            else
                            {
                                totalLost++;
                            }
                        }
                    }

                    attempts++;
                    if (attempts >= 10)
                    {
                        isServiceDown = true;
                        _logger.LogWarning("Service considered down after 10 attempts");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error fetching data from API");
                    isServiceDown = true;
                }
            }

            return (personsList, totalLost, attempts, isServiceDown);
        }

        public async Task<IEnumerable<DenizenGeneratorMonitoring>> GetMonitoringData()
        {
            return await _context.DenizenGeneratorMonitorings
                .OrderByDescending(m => m.Timestamps)
                .ToListAsync();
        }

        public async Task SaveMonitoringData(DenizenGeneratorMonitoring monitoring)
        {
            _context.DenizenGeneratorMonitorings.Add(monitoring);
            await _context.SaveChangesAsync();
        }
    }
}
