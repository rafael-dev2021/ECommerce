using Domain.Entities.Products.Fashion.T_Shirts.ObjectValues;
using FluentValidation;

namespace FluentValidations.Domain.Entities.Products.Fashion.T_Shirts.ObjectValues;

public class OtherFeaturesObjectValueValidator : AbstractValidator<OtherFeaturesObjectValue>
{
    public OtherFeaturesObjectValueValidator()
    {
        RuleFor(x => x.Composition)
            .NotEmpty().WithMessage("Composition cannot be empty.")
            .MaximumLength(15).WithMessage("Composition must have a maximum length of 15 characters.");

        RuleFor(x => x.MainMaterial)
            .NotEmpty().WithMessage("Main material cannot be empty.")
            .MaximumLength(15).WithMessage("Main material must have a maximum length of 15 characters.");

        RuleFor(x => x.UnitsPerKit)
            .GreaterThan(0).WithMessage("Units per kit must be greater than zero.");

        RuleFor(x => x.WithRecycledMaterials)
            .InclusiveBetween(false, true).WithMessage("WithRecycledMaterials must be either true or false.");

        RuleFor(x => x.ItsSporty)
            .InclusiveBetween(false, true).WithMessage("ItsSporty must be either true or false.");
    }
}