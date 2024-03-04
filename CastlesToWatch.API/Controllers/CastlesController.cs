using AutoMapper;
using CastlesToWatch.API.Model.Domain;
using CastlesToWatch.API.Model.DTO;
using CastlesToWatch.API.Repositories;
using CastlesToWatch.API.Validations;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles ="Admin,User")]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending)
        { 
        
            var castleDomain = await castleRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true);

            return Ok(mapper.Map<List<CastleDTO>>(castleDomain));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] CreateCastleDto createCastleDto)
        {
            var castleDomain = mapper.Map<Castle>(createCastleDto);

            await castleRepository.CreateAsync(castleDomain);
            return Ok(castleDomain.Id);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var castleDomain = await castleRepository.GetByIdAsync(id);
            if(castleDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CastleDTO>(castleDomain));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Admin")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateCastleDTO updateCastleDTO)
        {
            var castleDomain = mapper.Map<Castle>(updateCastleDTO);

            castleDomain = await castleRepository.UpdateAsync(id, castleDomain);
            if(castleDomain == null)
            {
                return NotFound();
            }
            return Ok("Updated");
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) { 
            var castleDomain = await castleRepository.DeleteAsync(id);
            if(castleDomain == null)
            {
                return NotFound();
            }
            return Ok("Deleted");
        }

    }
}
