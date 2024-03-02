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
        public async Task<List<Country>> GetAllAsync()
        {
            return await dbContext.Countries.ToListAsync();
        }
    }
}
