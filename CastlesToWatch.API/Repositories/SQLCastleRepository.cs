using CastlesToWatch.API.Data;
using CastlesToWatch.API.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace CastlesToWatch.API.Repositories
{
    public class SQLCastleRepository : ICastleRepository
    {
        private readonly CastlesDbContext dbContext;

        public SQLCastleRepository(CastlesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Castle> CreateAsync(Castle castle)
        {
            await dbContext.Castles.AddAsync(castle);
            await dbContext.SaveChangesAsync();
            return castle;
        }

        public async Task<List<Castle>> GetAllAsync(string? filterOn, string? filterQuery, string? sortBy, bool isAscending)
        {
           var castles = dbContext.Castles.Include("Country").AsQueryable();
            //Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {

                    castles = castles.Where(x => x.Name.Contains(filterQuery));
                }
            }
            //Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Rating", StringComparison.OrdinalIgnoreCase))
                {
                    castles = isAscending ? castles.OrderBy(x => x.Rating) : castles.OrderByDescending(x => x.Rating);
                }
                
            }
            return await castles.ToListAsync();
        }
    }
}
