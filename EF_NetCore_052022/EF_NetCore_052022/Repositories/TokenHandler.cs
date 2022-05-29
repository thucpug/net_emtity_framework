using EF_NetCore_052022.Models.Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EF_NetCore_052022.Repositories
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration configuration;

        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Task<string> CreateTokenAsync(User user)
        {
            //add claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, user.FirstName));
            claims.Add(new Claim(ClaimTypes.Surname, user.LastName));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            user.Roles.ForEach(e =>
            {
                claims.Add(new Claim(ClaimTypes.Role, e));
            });
            //create credentials
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //create Token Jwt
            JwtSecurityToken jwt = new JwtSecurityToken(
               configuration["Jwt:Issuer"],
               configuration["Jwt:Audience"],
               claims,
               expires: DateTime.Now.AddMinutes(15),
               signingCredentials: credentials);
            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(jwt));
        }
    }
}
