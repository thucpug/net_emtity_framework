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
        [Route("/all")]
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
        [Route("/allasync")]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
 
            var regions = await regionRepository.GetAllAsync();
            var regionDtos = mapper.Map<List<RegionDto>>(regions);


            return Ok(regionDtos);
        }

    }
}
