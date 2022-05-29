using EF_NetCore_052022.Models.Domain;

namespace EF_NetCore_052022.Repositories
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(User user);
    }
}
