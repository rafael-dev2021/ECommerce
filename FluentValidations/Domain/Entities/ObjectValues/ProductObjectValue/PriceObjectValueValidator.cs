using Domain.Entities.ObjectValues.ProductObjectValue;
using FluentValidation;

namespace FluentValidations.Domain.Entities.ObjectValues.ProductObjectValue;

public class PriceObjectValueValidator: AbstractValidator<PriceObjectValue>
{
    public PriceObjectValueValidator()
    {
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");

        RuleFor(x => x.HistoryPrice)
            .GreaterThanOrEqualTo(0).WithMessage("History price must be greater than or equal to zero.");
    }
}