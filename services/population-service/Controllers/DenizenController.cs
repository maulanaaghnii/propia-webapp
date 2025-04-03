using Microsoft.AspNetCore.Mvc;
using population_service.Models;
using population_service.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;

namespace population_service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DenizenController : ControllerBase
    {
        private readonly IDenizenService _denizenService;

        public DenizenController(IDenizenService denizenService)
        {
            _denizenService = denizenService;
        }

        // GET: /denizen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Denizen>>> GetAsync()
        {
            var denizens = await _denizenService.GetAllDenizensAsync();
            return Ok(new { data = denizens });
        }

        // GET: /denizen/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Denizen>> GetAsync(string id)
        {
            var denizen = await _denizenService.GetDenizenByIdAsync(id);
            if (denizen == null)
                return NotFound();

            return denizen;
        }

        // POST: /denizen
        [HttpPost]
        public async Task<ActionResult<object>> PostAsync([FromBody] JsonElement body)
        {
            try
            {
                if (body.ValueKind == JsonValueKind.Array)
                {
                    var denizens = JsonSerializer.Deserialize<List<Denizen>>(body.GetRawText());
                    if (denizens == null || !denizens.Any())
                        return BadRequest("Array cannot be empty");

                    var createdDenizens = new List<Denizen>();
                    foreach (var denizen in denizens)
                    {
                        var createdDenizen = await _denizenService.CreateDenizenAsync(denizen);
                        createdDenizens.Add(createdDenizen);
                    }

                    return Ok(new { message = $"{createdDenizens.Count} records created", data = createdDenizens });
                }
                else if (body.ValueKind == JsonValueKind.Object)
                {
                    var denizen = JsonSerializer.Deserialize<Denizen>(body.GetRawText());
                    if (denizen == null)
                        return BadRequest("Invalid denizen object");

                    var createdDenizen = await _denizenService.CreateDenizenAsync(denizen);
                    return CreatedAtAction(nameof(GetAsync), new { id = createdDenizen.Id }, createdDenizen);
                }

                return BadRequest("Invalid input format. Must be either an object or array of objects");
            }
            catch (JsonException ex)
            {
                return BadRequest($"Invalid JSON format: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: /denizen/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, [FromBody] Denizen denizen)
        {
            if (id != denizen.Id)
                return BadRequest();

            var success = await _denizenService.UpdateDenizenAsync(id, denizen);
            if (!success)
                return NotFound();

            return NoContent();
        }

        // DELETE: /denizen/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var success = await _denizenService.DeleteDenizenAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
