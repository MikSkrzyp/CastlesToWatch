using CastlesToWatch.API.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace CastlesToWatch.API.Data
{
    public class CastlesDbContext : DbContext
    {
        public CastlesDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Castle> Castles { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                 new Country { Id = Guid.Parse("88a55b5d-84c1-48c4-a67a-6743ed9128ae"), Name = "Italy", ShortName = "IT" },
                 new Country { Id = Guid.Parse("4b0745bc-5ab3-4018-a330-f6bed3bafb79"), Name = "Spain", ShortName = "ES" },
                 new Country { Id = Guid.Parse("c211f460-1878-4ff4-9348-8f5b196b8cf0"), Name = "Poland", ShortName = "PL" }
             );




        }
    }
}
