using AutoMapper;
using EF_NetCore_052022.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EF_NetCore_052022.Controllers
{
    [ApiController]
    [Route("Walk")]
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
        public async Task<IActionResult> Index()
        {
            var walks = await walkRepository.GetAllAsync();
            return Ok(walks);
        }
    }
}
