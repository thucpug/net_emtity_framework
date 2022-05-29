using EF_NetCore_052022.Models.DTO;
using FluentValidation;

namespace EF_NetCore_052022.Validators
{
    public class RegionDtoValidator: AbstractValidator<RegionDto>
    {
        public RegionDtoValidator()
        {
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x => x.Area).GreaterThan(0);
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x=>x.Population).GreaterThan(0);
        }
    }
}
