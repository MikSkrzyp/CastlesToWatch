using AutoMapper;
using CastlesToWatch.API.Data;
using CastlesToWatch.API.Model.Domain;
using CastlesToWatch.API.Model.DTO;
using CastlesToWatch.API.Repositories;
using CastlesToWatch.API.Validations;
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
            throw new Exception(); 
            return Ok(mapper.Map<List<Country>>(countriesDomain));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] CreateCountryDto createCountryDto)
        {
            var countryDomain = mapper.Map<Country>(createCountryDto);
             await countryRepository.CreateAsync(countryDomain);
            return Ok(countryDomain.Id);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var countryDomain = await countryRepository.GetByIdAsync(id);
            if(countryDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CountryDTO>(countryDomain));
        }
    }
}
