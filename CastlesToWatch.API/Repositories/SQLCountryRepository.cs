using CastlesToWatch.API.Data;
using CastlesToWatch.API.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace CastlesToWatch.API.Repositories
{
    public class SQLCountryRepository : ICountryRepository
    {
        private readonly CastlesDbContext dbContext;

        public SQLCountryRepository(CastlesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Country> CreateAsync(Country country)
        {
            await dbContext.AddAsync(country);
            await dbContext.SaveChangesAsync();
            return country;
        }

        public async Task<List<Country>> GetAllAsync()
        {
            return await dbContext.Countries.ToListAsync();
        }

        public async Task<Country?> GetByIdAsync(Guid id)
        {
            return await dbContext.Countries.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
