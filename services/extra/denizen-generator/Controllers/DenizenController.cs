using Microsoft.AspNetCore.Mvc;
using denizen_generator.Models;
using denizen_generator.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace denizen_generator.Controllers
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
        public async Task<ActionResult<Denizen>> Post([FromBody] Denizen denizen)
        {
            // Generate UUID untuk Id baru
            denizen.Id = Guid.NewGuid().ToString();

            _context.Denizens.Add(denizen);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = denizen.Id }, denizen);
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
