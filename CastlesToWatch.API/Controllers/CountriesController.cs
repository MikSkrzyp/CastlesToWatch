using AutoMapper;
using CastlesToWatch.API.Data;
using CastlesToWatch.API.Model.Domain;
using CastlesToWatch.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CastlesToWatch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly CastlesDbContext dbContext;
        private readonly ICountryRepository countryRepository;
        private readonly IMapper mapper;

        public CountriesController(CastlesDbContext dbContext,ICountryRepository countryRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.countryRepository = countryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countriesDomain = await countryRepository.GetAllAsync();
            return Ok(mapper.Map<List<Country>>(countriesDomain));
        }
    }
}
