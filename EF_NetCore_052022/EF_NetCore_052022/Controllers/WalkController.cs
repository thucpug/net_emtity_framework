using AutoMapper;
using EF_NetCore_052022.Models.Domain;
using EF_NetCore_052022.Models.DTO;
using EF_NetCore_052022.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EF_NetCore_052022.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class WalkController : Controller
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalkController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("Walks")]
        public async Task<IActionResult> GetAll()
        {
            var walks = await walkRepository.GetAllAsync();
            var walkDtos = mapper.Map<IEnumerable<WalkDto>>(walks);
            return Ok(walkDtos);
        }
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkByid")]
        public async Task<IActionResult> GetWalkByid(Guid id)
        {

            var walk = await walkRepository.GetAsync(id);
            if (walk == null) return NotFound();
            var walkDtoResponse = mapper.Map<WalkDto>(walk);
            return Ok(walkDtoResponse);
        }
        [HttpGet]
        [ActionName("GetWalkByid")]
        public async Task<IActionResult> GetWalkByQueryId([FromQuery(Name ="Id")] Guid Id)
        {

            var walk = await walkRepository.GetAsync(Id);
            if (walk == null) return NotFound();
            var walkDtoResponse = mapper.Map<WalkDto>(walk);
            return Ok(walkDtoResponse);
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateWalk([FromBody] WalkRequestDto walkDto)
        {
            Walk walk = mapper.Map<Walk>(walkDto);
            var walkReponsitory = await walkRepository.AddAsync(walk);
            var walkDtoResponse = mapper.Map<WalkDto>(walkReponsitory);
            return CreatedAtAction(nameof(GetWalkByid), new { id = walkDtoResponse.Id }, walkDtoResponse);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {

            var walkResponse = await walkRepository.DeleteAsync(id);
            if (walkResponse == null) return NotFound();

            var walkDtoResponse = mapper.Map<WalkDto>(walkResponse);
            return Ok(walkDtoResponse);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id, [FromBody] WalkRequestDto walkDto)
        {
            Walk walk = mapper.Map<Walk>(walkDto);

            var walkResponse = await walkRepository.UpdateAsync(id, walk);
            if (walkResponse == null) return NotFound();

            var walkDtoResponse = mapper.Map<WalkDto>(walkResponse);
            return AcceptedAtAction(nameof(GetWalkByid), new { id = id }, walkDtoResponse);
        }
    }
}
