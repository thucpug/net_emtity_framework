using AutoMapper;
using EF_NetCore_052022.Models.Domain;
using EF_NetCore_052022.Models.DTO;

namespace EF_NetCore_052022.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            //CreateMap<Region, RegionDto>()
            //    .ForMember(
            //    dest => dest.IdDto, options => options.MapFrom(src => src.Id))
            //    .ForMember(
            //    dest => dest.NameDto, options => options.MapFrom(src => src.Name))
            //    .ReverseMap();
            CreateMap<Region, RegionDto>().ReverseMap();
        }
    }
}
