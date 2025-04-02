using Microsoft.EntityFrameworkCore;
using denizen_generator.Models;

namespace denizen_generator.Data
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
