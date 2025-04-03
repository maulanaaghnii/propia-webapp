using Microsoft.EntityFrameworkCore;
using population_service.Data;
using population_service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace population_service.Services
{
    public class DenizenService : IDenizenService
    {
        private readonly ApplicationDbContext _context;

        public DenizenService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Denizen>> GetAllDenizensAsync()
        {
            return await _context.Denizens.ToListAsync();
        }

        public async Task<Denizen?> GetDenizenByIdAsync(string id)
        {
            return await _context.Denizens.FindAsync(id);
        }

        public async Task<Denizen> CreateDenizenAsync(Denizen denizen)
        {
            if (string.IsNullOrEmpty(denizen.Id))
            {
                denizen.Id = Guid.NewGuid().ToString();
            }

            _context.Denizens.Add(denizen);
            await _context.SaveChangesAsync();
            return denizen;
        }

        public async Task<bool> UpdateDenizenAsync(string id, Denizen denizen)
        {
            if (id != denizen.Id)
                return false;

            _context.Entry(denizen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DenizenExistsAsync(id))
                    return false;
                throw;
            }
        }

        public async Task<bool> DeleteDenizenAsync(string id)
        {
            var denizen = await _context.Denizens.FindAsync(id);
            if (denizen == null)
                return false;

            _context.Denizens.Remove(denizen);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<bool> DenizenExistsAsync(string id)
        {
            return await _context.Denizens.AnyAsync(e => e.Id == id);
        }
    }
}
