using Microsoft.AspNetCore.Mvc;
using population_service.Models;
using population_service.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace population_service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DenizenController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DenizenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /denizen
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { data = _context.Denizens.ToList()});
        }

        // GET: /denizen/{id}
        [HttpGet("{id}")]
        public ActionResult<Denizen> Get(string id)
        {
            var denizen = _context.Denizens.Find(id);
            if (denizen == null)
                return NotFound();

            return denizen;
        }

        // POST: /denizen
        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] object body)
        {
            try
            {
                if (body is JsonElement element)
                {
                    if (element.ValueKind == JsonValueKind.Array)
                    {
                        // Handle array input
                        var denizens = JsonSerializer.Deserialize<List<Denizen>>(element.GetRawText());
                        if (denizens == null || !denizens.Any())
                            return BadRequest("Array cannot be empty");

                        foreach (var denizen in denizens)
                        {
                            denizen.Id = Guid.NewGuid().ToString();
                            _context.Denizens.Add(denizen);
                        }
                        await _context.SaveChangesAsync();
                        return Ok(new { message = $"{denizens.Count} records created", data = denizens });
                    }
                    else if (element.ValueKind == JsonValueKind.Object)
                    {
                        // Handle single object input
                        var denizen = JsonSerializer.Deserialize<Denizen>(element.GetRawText());
                        if (denizen == null)
                            return BadRequest("Invalid denizen object");

                        denizen.Id = Guid.NewGuid().ToString();
                        _context.Denizens.Add(denizen);
                        await _context.SaveChangesAsync();
                        return CreatedAtAction(nameof(Get), new { id = denizen.Id }, denizen);
                    }
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
        public IActionResult Put(string id, [FromBody] Denizen denizen)
        {
            var existingDenizen = _context.Denizens.Find(id);
            if (existingDenizen == null)
                return NotFound();

            denizen.Id = id;
            _context.Entry(existingDenizen).CurrentValues.SetValues(denizen);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: /denizen/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var denizen = _context.Denizens.Find(id);
            if (denizen == null)
                return NotFound();

            _context.Denizens.Remove(denizen);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
