using Domain.Entities.Products.Technology.Smartphones.ObjectValues;
using FluentValidation;

namespace FluentValidations.Domain.Entities.Products.Technology.Smartphones.ObjectValues;

public class FeatureObjectValueValidator : AbstractValidator<FeatureObjectValue>
{
    public FeatureObjectValueValidator()
    {
        RuleFor(x => x.CellNetworkTechnology)
            .NotEmpty().WithMessage("Cell network technology cannot be empty.")
            .MaximumLength(30).WithMessage("Cell network technology must have a maximum length of 30 characters.");

        RuleFor(x => x.VirtualAssistant)
            .NotEmpty().WithMessage("Virtual assistant cannot be empty.")
            .MaximumLength(50).WithMessage("Virtual assistant must have a maximum length of 50 characters.");

        RuleFor(x => x.ManufacturerPartNumber)
            .NotEmpty().WithMessage("Manufacturer part number cannot be empty.")
            .MaximumLength(50).WithMessage("Manufacturer part number must have a maximum length of 50 characters.");
    }
}