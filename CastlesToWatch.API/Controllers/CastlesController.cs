using AutoMapper;
using CastlesToWatch.API.Model.Domain;
using CastlesToWatch.API.Model.DTO;
using CastlesToWatch.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CastlesToWatch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastlesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICastleRepository castleRepository;

        public CastlesController(IMapper mapper, ICastleRepository castleRepository)
        {
            this.mapper = mapper;
            this.castleRepository = castleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending)
        { 
        
            var castleDomain = await castleRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true);

            return Ok(mapper.Map<List<CastleDTO>>(castleDomain));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCastleDto createCastleDto)
        {
            var castleDomain = mapper.Map<Castle>(createCastleDto);

            await castleRepository.CreateAsync(castleDomain);
            return Ok(mapper.Map<CastleDTO>(castleDomain));
        }

    }
}
