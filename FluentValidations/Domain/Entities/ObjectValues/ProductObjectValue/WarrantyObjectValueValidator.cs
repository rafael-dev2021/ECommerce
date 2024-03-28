using Domain.Entities.ObjectValues.ProductObjectValue;
using FluentValidation;

namespace FluentValidations.Domain.Entities.ObjectValues.ProductObjectValue;

public class WarrantyObjectValueValidator : AbstractValidator<WarrantyObjectValue>
{
    public WarrantyObjectValueValidator()
    {
        RuleFor(x => x.WarrantyLength)
            .NotEmpty().WithMessage("Warranty length cannot be empty.")
            .MaximumLength(30).WithMessage("Warranty length must have a maximum length of 30 characters.");

        RuleFor(x => x.WarrantyInformation)
            .NotEmpty().WithMessage("Warranty information cannot be empty.")
            .MaximumLength(50).WithMessage("Warranty information must have a maximum length of 50 characters.");
    }
}