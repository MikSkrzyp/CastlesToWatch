using Microsoft.EntityFrameworkCore;

namespace CastlesToWatch.API.Model
{
    public class CastlesDbContext : DbContext
    {
        public CastlesDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Castle> Castles { get; set; }
    }
}
