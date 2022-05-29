using EF_NetCore_052022.Models.Domain;

namespace EF_NetCore_052022.Repositories
{
    public interface IUserRepository
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}
