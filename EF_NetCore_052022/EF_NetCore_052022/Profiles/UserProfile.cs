using AutoMapper;
using EF_NetCore_052022.Models.Domain;
using EF_NetCore_052022.Models.DTO;

namespace EF_NetCore_052022.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, LoginRequest>().ReverseMap();

        }
    }
}
