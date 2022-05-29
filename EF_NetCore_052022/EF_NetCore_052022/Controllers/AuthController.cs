using AutoMapper;
using EF_NetCore_052022.Models.Domain;
using EF_NetCore_052022.Models.DTO;
using EF_NetCore_052022.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EF_NetCore_052022.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenHandler tokenHandler;
        private readonly IMapper mapper;

        public AuthController(IUserRepository userRepository, ITokenHandler tokenHandler, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.tokenHandler = tokenHandler;
            this.mapper = mapper;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest loginRequest)
        {
            User user = await userRepository.AuthenticateAsync(loginRequest.Username, loginRequest.Password);
            if (user != null)
            {
                //Generate Jwt

                var token = await tokenHandler.CreateTokenAsync(user);
                return Ok(token);

            }
            return BadRequest($"Username or Password is incorrect!");
        }
    }
}
