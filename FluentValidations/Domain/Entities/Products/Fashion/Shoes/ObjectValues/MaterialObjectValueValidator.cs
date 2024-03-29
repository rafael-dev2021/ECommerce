using Domain.Entities.Products.Fashion.Shoes.ObjectValues;
using FluentValidation;

namespace FluentValidations.Domain.Entities.Products.Fashion.Shoes.ObjectValues;

public class MaterialObjectValueValidator: AbstractValidator<MaterialObjectValue>
{
    public MaterialObjectValueValidator()
    {
        RuleFor(x => x.MaterialsFromAbroad)
            .NotEmpty().WithMessage("Materials from abroad cannot be empty.")
            .MaximumLength(10).WithMessage("Materials from abroad must have a maximum length of 10 characters.");

        RuleFor(x => x.InteriorMaterials)
            .NotEmpty().WithMessage("Interior materials cannot be empty.")
            .MaximumLength(10).WithMessage("Interior materials must have a maximum length of 10 characters.");

        RuleFor(x => x.SoleMaterials)
            .NotEmpty().WithMessage("Sole materials cannot be empty.")
            .MaximumLength(10).WithMessage("Sole materials must have a maximum length of 10 characters.");
    }
    
}