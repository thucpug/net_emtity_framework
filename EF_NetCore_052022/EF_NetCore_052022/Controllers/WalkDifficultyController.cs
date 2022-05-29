using AutoMapper;
using EF_NetCore_052022.Models.Domain;
using EF_NetCore_052022.Models.DTO;
using EF_NetCore_052022.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EF_NetCore_052022.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultyController : Controller
    {
        private readonly IWalkDifficultyRepository walkDifficultyRepository;
        private readonly IMapper mapper;

        public WalkDifficultyController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
        {
            this.walkDifficultyRepository = walkDifficultyRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("WalkDifficulties")]

        public async Task<IActionResult> GetAll()
        {
            var walkDifficulties = await walkDifficultyRepository.GetAllAsync();
            var walkDtoDifficulties = mapper.Map<IEnumerable<WalkDifficultyDto>>(walkDifficulties);
            return Ok(walkDtoDifficulties);
        }
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkDifficulty")]
        public async Task<IActionResult> GetWalkDifficulty([FromRoute] Guid id)
        {
            var walkDifficulty = await walkDifficultyRepository.GetAsync(id);
            var walkDtoDifficulty = mapper.Map<WalkDifficultyDto>(walkDifficulty);
            return Ok(walkDtoDifficulty);
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] WalkDifficultyDto dto)
        {
            WalkDifficulty walkDifficulty = mapper.Map<WalkDifficulty>(dto);

            var walkDifficultyResponse = await walkDifficultyRepository.AddAsync(walkDifficulty);
            var walkDifficultyDtoResponse = mapper.Map<WalkDifficultyDto>(walkDifficultyResponse);
            return CreatedAtAction(nameof(GetWalkDifficulty), new { id = walkDifficultyDtoResponse.Id }, walkDifficultyDtoResponse);
        }
        [HttpPut]
        [Route("Update/{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] WalkDifficultyDto dto)
        {
            WalkDifficulty walkDifficulty = mapper.Map<WalkDifficulty>(dto);

            var walkDifficultyResponse = await walkDifficultyRepository.UpdateAsync(id, walkDifficulty);
            var walkDifficultyDtoResponse = mapper.Map<WalkDifficultyDto>(walkDifficultyResponse);
            return AcceptedAtAction(nameof(GetWalkDifficulty), new { id = walkDifficultyDtoResponse.Id }, walkDifficultyDtoResponse);
        }
        [HttpDelete]
        [Route("Delete/{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDifficultyResponse = await walkDifficultyRepository.DeleteAsync(id);
            var walkDifficultyDtoResponse = mapper.Map<WalkDifficultyDto>(walkDifficultyResponse);
            return Ok(walkDifficultyDtoResponse);
        }
    }
}
