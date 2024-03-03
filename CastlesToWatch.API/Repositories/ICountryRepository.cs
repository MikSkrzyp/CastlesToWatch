using CastlesToWatch.API.Model.Domain;

namespace CastlesToWatch.API.Repositories
{
    public interface ICountryRepository
    {

       Task<List<Country>> GetAllAsync();
        Task<Country> CreateAsync(Country country);
        Task<Country?> GetByIdAsync(Guid id);
    }
}
