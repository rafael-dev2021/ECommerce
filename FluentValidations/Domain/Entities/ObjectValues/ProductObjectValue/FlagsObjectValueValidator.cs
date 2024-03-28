using Domain.Entities.ObjectValues.ProductObjectValue;
using FluentValidation;

namespace FluentValidations.Domain.Entities.ObjectValues.ProductObjectValue;

public class FlagsObjectValueValidator: AbstractValidator<FlagsObjectValue>
{
    public FlagsObjectValueValidator()
    {
        RuleFor(x => x.IsFavorite)
            .NotEqual(true).When(x => x.IsDailyOffer)
            .WithMessage("Cannot be favorite and daily offer at the same time.");

        RuleFor(x => x.IsBestSeller)
            .NotEqual(true).When(x => x.IsDailyOffer)
            .WithMessage("Cannot be best seller and daily offer at the same time.");
    }
}