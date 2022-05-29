using EF_NetCore_052022.Models.Domain;

namespace EF_NetCore_052022.Repositories
{
    public class StaticUserRepository : IUserRepository
    {
        List<User> users = new List<User> {
            new User {
                Id = Guid.NewGuid(),
                Username ="readonly@user",
                Email ="readonly@mail.com",
                Password ="readonly@user",
                FirstName ="readonly",
                LastName ="role",
                Roles =new List<string>{"read"}
            } ,
            new User {
                Id = Guid.NewGuid(),
                Username ="readwrite@user",
                Email ="readwrite@mail.com",
                Password ="readwrite@user",
                FirstName ="readwrite",
                LastName ="role",
                Roles =new List<string>{"read","write"} }
        };
        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = users.Find(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase)
                && x.Password == password);
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}
