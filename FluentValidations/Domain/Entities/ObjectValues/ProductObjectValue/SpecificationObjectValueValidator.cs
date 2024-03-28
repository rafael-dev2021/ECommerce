using Domain.Entities.ObjectValues.ProductObjectValue;
using FluentValidation;

namespace FluentValidations.Domain.Entities.ObjectValues.ProductObjectValue;

public class SpecificationObjectValueValidator: AbstractValidator<SpecificationObjectValue>
{
    public SpecificationObjectValueValidator()
    {
        RuleFor(x => x.Model)
            .NotEmpty().WithMessage("Model cannot be empty.")
            .MaximumLength(50).WithMessage("Model must have a maximum length of 50 characters.");
        
        RuleFor(x => x.Brand)
            .NotEmpty().WithMessage("Brand cannot be empty.")
            .MaximumLength(20).WithMessage("Brand must have a maximum length of 20 characters.");

        RuleFor(x => x.Line)
            .NotEmpty().WithMessage("Line cannot be empty.")
            .MaximumLength(20).WithMessage("Line must have a maximum length of 20 characters.");

        RuleFor(x => x.Weight)
            .NotEmpty().WithMessage("Weight cannot be empty.")
            .MaximumLength(20).WithMessage("Weight must have a maximum length of 20 characters.");

        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Type cannot be empty.")
            .MaximumLength(20).WithMessage("Type must have a maximum length of 20 characters.");
    }
}