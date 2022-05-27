using AutoMapper;
using EF_NetCore_052022.Models.Domain;
using EF_NetCore_052022.Models.DTO;
using EF_NetCore_052022.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EF_NetCore_052022.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("all")]
        public IActionResult GetAllRegions()
        {
            //var regions = new List<Region>()
            //{
            //    new Region()
            //    {
            //        Id =  Guid.NewGuid(),
            //        Name = "thuc",
            //        Area = 42554323,
            //    }
            //};
            var regions = regionRepository.GetAll();
            var regionDtos = mapper.Map<List<RegionDto>>(regions);


            return Ok(regionDtos);
        }
        [HttpGet]
        [Route("allasync")]
        public async Task<IActionResult> GetAllRegionsAsync()
        {

            var regions = await regionRepository.GetAllAsync();
            var regionDtos = mapper.Map<List<RegionDto>>(regions);


            return Ok(regionDtos);
        }
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionById")]
        public async Task<IActionResult> GetRegionById(Guid id)
        {

            var regions = await regionRepository.GetAsync(id);
            if (regions == null) return NotFound();
            var regionDtos = mapper.Map<RegionDto>(regions);
            return Ok(regionDtos);
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateRegionAsync(RegionDto regionDto)
        {
            Region region = mapper.Map<Region>(regionDto);
            var regionResponse = await regionRepository.AddSync(region);
            var regionDtoResponse = mapper.Map<RegionDto>(regionResponse);
            return CreatedAtAction(nameof(GetRegionById), new { id = regionDtoResponse.IdDto }, regionDtoResponse);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {

            var regionResponse = await regionRepository.DeleteAsync(id);
            if (regionResponse == null) return NotFound();

            var regionDtoResponse = mapper.Map<RegionDto>(regionResponse);
            return Ok(regionDtoResponse);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id, [FromBody] RegionDto regionDto)
        {
            Region region = mapper.Map<Region>(regionDto);

            var regionResponse = await regionRepository.UpdateAsync(id, region);
            if (regionResponse == null) return NotFound();

            var regionDtoResponse = mapper.Map<RegionDto>(regionResponse);
            return AcceptedAtAction(nameof(GetRegionById), new { id = id }, regionDtoResponse);
        }
    }
}
