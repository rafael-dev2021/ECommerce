using Domain.Entities.Products.Fashion.T_Shirts.ObjectValues;
using FluentValidation;

namespace FluentValidations.Domain.Entities.Products.Fashion.T_Shirts.ObjectValues;

public class MainFeaturesObjectValueValidator: AbstractValidator<MainFeaturesObjectValue>
{
    public MainFeaturesObjectValueValidator()
    {
        RuleFor(x => x.TypeOfClothing)
            .NotEmpty().WithMessage("Type of clothing cannot be empty.")
            .MaximumLength(15).WithMessage("Type of clothing must have a maximum length of 15 characters.");

        RuleFor(x => x.FabricDesign)
            .NotEmpty().WithMessage("Fabric design cannot be empty.")
            .MaximumLength(15).WithMessage("Fabric design must have a maximum length of 15 characters.");
    }
    
}