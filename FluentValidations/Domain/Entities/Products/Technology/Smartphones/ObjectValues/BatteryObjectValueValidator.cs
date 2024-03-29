using Domain.Entities.Products.Technology.Smartphones.ObjectValues;
using FluentValidation;

namespace FluentValidations.Domain.Entities.Products.Technology.Smartphones.ObjectValues;

public class BatteryObjectValueValidator: AbstractValidator<BatteryObjectValue>
{
    public BatteryObjectValueValidator()
    {
        RuleFor(x => x.BatteryType)
            .NotEmpty().WithMessage("Battery type cannot be empty.")
            .MaximumLength(20).WithMessage("Battery type must have a maximum length of 20 characters.");

        RuleFor(x => x.BatteryCapacityMAh)
            .GreaterThan(0).WithMessage("Battery capacity must be greater than zero.");
        
        RuleFor(x => x.IsBatteryRemovable)
            .Equal(true).WithMessage("Is battery removable must be true or false.");
    }
}
    
