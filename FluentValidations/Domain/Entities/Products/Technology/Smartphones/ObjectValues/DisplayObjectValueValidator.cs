using Domain.Entities.Products.Technology.Smartphones.ObjectValues;
using FluentValidation;

namespace FluentValidations.Domain.Entities.Products.Technology.Smartphones.ObjectValues;

public class DisplayObjectValueValidator: AbstractValidator<DisplayObjectValue>
{
    public DisplayObjectValueValidator()
    {
        RuleFor(x => x.DisplayType)
            .NotEmpty().WithMessage("Display type cannot be empty.")
            .MaximumLength(30).WithMessage("Display type must have a maximum length of 30 characters.");

        RuleFor(x => x.DisplayResolution)
            .NotEmpty().WithMessage("Display resolution cannot be empty.")
            .MaximumLength(25).WithMessage("Display resolution must have a maximum length of 25 characters.");

        RuleFor(x => x.DisplayProtection)
            .NotEmpty().WithMessage("Display protection cannot be empty.")
            .MaximumLength(40).WithMessage("Display protection must have a maximum length of 40 characters.");

        RuleFor(x => x.DisplaySizeInches)
            .GreaterThan(0).WithMessage("Display size in inches must be greater than zero.");
    }
}