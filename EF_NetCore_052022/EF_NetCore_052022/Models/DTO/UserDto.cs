namespace EF_NetCore_052022.Models.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
