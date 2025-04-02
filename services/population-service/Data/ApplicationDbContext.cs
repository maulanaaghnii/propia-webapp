using Microsoft.EntityFrameworkCore;
using population_service.Models;

namespace population_service.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Denizen> Denizens { get; set; }
    }
}
