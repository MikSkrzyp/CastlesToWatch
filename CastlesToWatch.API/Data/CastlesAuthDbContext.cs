﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CastlesToWatch.API.Data
{
    public class CastlesAuthDbContext : IdentityDbContext
    {
        public CastlesAuthDbContext(DbContextOptions<CastlesAuthDbContext> options) : base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            
            var adminRoleId = "778825e2-c3db-4f5b-86e9-36085d9128ec";

            var roles = new List<IdentityRole>
            {
               new IdentityRole
               {
                   Id = adminRoleId,
                   ConcurrencyStamp = adminRoleId,
                   Name = "Admin",
                   NormalizedName = "Admin".ToUpper()
               }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
