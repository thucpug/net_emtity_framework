using AutoMapper;
using EF_NetCore_052022.Models.Domain;
using EF_NetCore_052022.Models.DTO;

namespace EF_NetCore_052022.Profiles
{
    public class WalkDifficultyProfile : Profile
    {
        public WalkDifficultyProfile()
        {
            CreateMap<WalkDifficulty, WalkDifficultyDto>().ReverseMap();
        }
    }
}
