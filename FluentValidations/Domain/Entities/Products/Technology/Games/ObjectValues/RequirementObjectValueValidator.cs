using Domain.Entities.Products.Technology.Games.ObjectValues;
using FluentValidation;

namespace FluentValidations.Domain.Entities.Products.Technology.Games.ObjectValues;

public class RequirementObjectValueValidator: AbstractValidator<RequirementObjectValue>
{
    public RequirementObjectValueValidator()
    {
        RuleFor(x => x.MinimumRamRequirementInMb)
            .NotEmpty().WithMessage("Minimum RAM requirement cannot be empty.")
            .GreaterThanOrEqualTo(4).WithMessage("Minimum RAM requirement must be greater than or equal to 4 GB (4096 MB).")
            .LessThanOrEqualTo(16).WithMessage("Minimum RAM requirement must be less than or equal to 16 GB (16384 MB).");
        
        RuleFor(x => x.MinimumOperatingSystemsRequired)
            .NotEmpty().WithMessage("Minimum operating systems required cannot be empty.")
            .MaximumLength(10).WithMessage("Minimum operating systems required must have a maximum length of 10 characters.");

        RuleFor(x => x.MinimumGraphicsProcessorsRequired)
            .NotEmpty().WithMessage("Minimum graphics processors required cannot be empty.")
            .MaximumLength(10).WithMessage("Minimum graphics processors required must have a maximum length of 10 characters.");

        RuleFor(x => x.MinimumProcessorsRequired)
            .NotEmpty().WithMessage("Minimum processors required cannot be empty.")
            .MaximumLength(10).WithMessage("Minimum processors required must have a maximum length of 10 characters.");
    }
}