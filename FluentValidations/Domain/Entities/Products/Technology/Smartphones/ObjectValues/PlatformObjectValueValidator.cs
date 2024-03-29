using Domain.Entities.Products.Technology.Smartphones.ObjectValues;
using FluentValidation;

namespace FluentValidations.Domain.Entities.Products.Technology.Smartphones.ObjectValues;

public class PlatformObjectValueValidator: AbstractValidator<PlatformObjectValue>
{
    public PlatformObjectValueValidator()
    {
        RuleFor(x => x.OperatingSystem)
            .NotEmpty().WithMessage("Operating system cannot be empty.")
            .MaximumLength(15).WithMessage("Operating system must have a maximum length of 15 characters.");

        RuleFor(x => x.Chipset)
            .NotEmpty().WithMessage("Chipset cannot be empty.")
            .MaximumLength(50).WithMessage("Chipset must have a maximum length of 50 characters.");

        RuleFor(x => x.Gpu)
            .NotEmpty().WithMessage("GPU cannot be empty.")
            .MaximumLength(30).WithMessage("GPU must have a maximum length of 30 characters.");

        RuleFor(x => x.Cpu)
            .NotEmpty().WithMessage("CPU cannot be empty.")
            .MaximumLength(30).WithMessage("CPU must have a maximum length of 30 characters.");
    }
}