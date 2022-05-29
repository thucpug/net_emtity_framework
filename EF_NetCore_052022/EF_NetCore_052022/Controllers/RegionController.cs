using AutoMapper;
using EF_NetCore_052022.Models.Domain;
using EF_NetCore_052022.Models.DTO;
using EF_NetCore_052022.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EF_NetCore_052022.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
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
        [Route("All")]
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
        [Route("AllAsync")]
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
            //if (!this.ValidateAddRegionAsync(regionDto))
            //{
            //    return BadRequest(ModelState);
            //}
            Region region = mapper.Map<Region>(regionDto);
            var regionResponse = await regionRepository.AddSync(region);
            var regionDtoResponse = mapper.Map<RegionDto>(regionResponse);
            return CreatedAtAction(nameof(GetRegionById), new { id = regionDtoResponse.Id }, regionDtoResponse);
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
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] RegionDto regionDto)
        {
            //if (!this.ValidateAddRegionAsync(regionDto))
            //{
            //    return BadRequest(ModelState);
            //}
            Region region = mapper.Map<Region>(regionDto);

            var regionResponse = await regionRepository.UpdateAsync(id, region);
            if (regionResponse == null) return NotFound();

            var regionDtoResponse = mapper.Map<RegionDto>(regionResponse);
            return AcceptedAtAction(nameof(GetRegionById), new { id = id }, regionDtoResponse);
        }
        #region Private methods

        private bool ValidateAddRegionAsync(RegionDto addRegionRequest)
        {
            if (addRegionRequest == null)
            {
                ModelState.AddModelError(nameof(addRegionRequest),
                    $"Add Region Data is required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(addRegionRequest.Code))
            {
                ModelState.AddModelError(nameof(addRegionRequest.Code),
                    $"{nameof(addRegionRequest.Code)} cannot be null or empty or white space.");
            }

            if (string.IsNullOrWhiteSpace(addRegionRequest.Name))
            {
                ModelState.AddModelError(nameof(addRegionRequest.Name),
                    $"{nameof(addRegionRequest.Name)} cannot be null or empty or white space.");
            }

            if (addRegionRequest.Area <= 0)
            {
                ModelState.AddModelError(nameof(addRegionRequest.Area),
                    $"{nameof(addRegionRequest.Area)} cannot be less than or equal to zero.");
            }

            if (addRegionRequest.Population < 0)
            {
                ModelState.AddModelError(nameof(addRegionRequest.Population),
                    $"{nameof(addRegionRequest.Population)} cannot be less than zero.");
            }

            if (ModelState.ErrorCount > 0)
            {
                return false;
            }

            return true;
        }

        private bool ValidateUpdateRegionAsync(RegionDto updateRegionRequest)
        {
            if (updateRegionRequest == null)
            {
                ModelState.AddModelError(nameof(updateRegionRequest),
                    $"Add Region Data is required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(updateRegionRequest.Code))
            {
                ModelState.AddModelError(nameof(updateRegionRequest.Code),
                    $"{nameof(updateRegionRequest.Code)} cannot be null or empty or white space.");
            }

            if (string.IsNullOrWhiteSpace(updateRegionRequest.Name))
            {
                ModelState.AddModelError(nameof(updateRegionRequest.Name),
                    $"{nameof(updateRegionRequest.Name)} cannot be null or empty or white space.");
            }

            if (updateRegionRequest.Area <= 0)
            {
                ModelState.AddModelError(nameof(updateRegionRequest.Area),
                    $"{nameof(updateRegionRequest.Area)} cannot be less than or equal to zero.");
            }

            if (updateRegionRequest.Population < 0)
            {
                ModelState.AddModelError(nameof(updateRegionRequest.Population),
                    $"{nameof(updateRegionRequest.Population)} cannot be less than zero.");
            }

            if (ModelState.ErrorCount > 0)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
