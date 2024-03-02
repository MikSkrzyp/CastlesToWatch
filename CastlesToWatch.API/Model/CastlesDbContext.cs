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



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                 new Country { Id = 1, Name = "Italy", ShortName = "IT" },
                 new Country { Id = 2, Name = "Spain", ShortName = "ES" },
                 new Country { Id = 3, Name = "Poland", ShortName = "PL" }
             );

            modelBuilder.Entity<Castle>().HasData(
                 new Castle
                 {
                     Id = 1,
                     Name = "Zamek Krzyzacki Malbork",
                     Address = "Staroscinska 1, 82-200 Malbork",
                     CountryId = 3,
                     Rating = 5
                 },
                 new Castle
                 {
                     Id = 2,
                     Name = "Castello Sforzesco",
                     Address = "Piazza Castello, 20121 Milano",
                     CountryId = 1,
                     Rating = 4
                 },
                  new Castle
                  {
                      Id = 3,
                      Name = "Zamek Ogrodzieniec",
                      Address = "Zamkowa, 42-440 Podzamcze",
                      CountryId = 3,
                      Rating = 3
                  }
             );


        }
    }
}
