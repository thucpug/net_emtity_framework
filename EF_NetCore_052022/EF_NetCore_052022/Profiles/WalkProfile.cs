using AutoMapper;
using EF_NetCore_052022.Models.Domain;
using EF_NetCore_052022.Models.DTO;

namespace EF_NetCore_052022.Profiles
{
    public class WalkProfile : Profile
    {
        public WalkProfile()
        {
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Walk, WalkRequestDto>().ReverseMap();
            
        }
    }
}
