using population_service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace population_service.Services
{
    public interface IDenizenService
    {
        Task<IEnumerable<Denizen>> GetAllDenizensAsync();
        Task<Denizen?> GetDenizenByIdAsync(string id);
        Task<Denizen> CreateDenizenAsync(Denizen denizen);
        Task<bool> UpdateDenizenAsync(string id, Denizen denizen);
        Task<bool> DeleteDenizenAsync(string id);
    }
}
