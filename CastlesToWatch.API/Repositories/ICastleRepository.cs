using CastlesToWatch.API.Model.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CastlesToWatch.API.Repositories
{
    public interface ICastleRepository
    {
        Task<List<Castle>> GetAllAsync(string? filterOn, string? filterQuery,
             string? sortBy, bool isAscending);

        Task<Castle> CreateAsync(Castle castle);
        Task<Castle?> GetByIdAsync(Guid id);
        Task<Castle?> UpdateAsync(Guid id, Castle castle);
        Task<Castle?> DeleteAsync(Guid id);

    }
}
