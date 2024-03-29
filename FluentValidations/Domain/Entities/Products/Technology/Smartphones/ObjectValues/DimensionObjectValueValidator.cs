using Domain.Entities.Products.Technology.Smartphones.ObjectValues;
using FluentValidation;

namespace FluentValidations.Domain.Entities.Products.Technology.Smartphones.ObjectValues;

public class DimensionObjectValueValidator: AbstractValidator<DimensionObjectValue>
{
    public DimensionObjectValueValidator()
    {
        RuleFor(x => x.HeightInches)
            .NotEmpty().WithMessage("Height in inches cannot be empty.")
            .GreaterThan(0).WithMessage("Height in inches must be greater than zero.");

        RuleFor(x => x.WidthInches)
            .NotEmpty().WithMessage("Width in inches cannot be empty.")
            .GreaterThan(0).WithMessage("Width in inches must be greater than zero.");

        RuleFor(x => x.ThicknessInches)
            .NotEmpty().WithMessage("Thickness in inches cannot be empty.")
            .GreaterThan(0).WithMessage("Thickness in inches must be greater than zero.");
    }
}