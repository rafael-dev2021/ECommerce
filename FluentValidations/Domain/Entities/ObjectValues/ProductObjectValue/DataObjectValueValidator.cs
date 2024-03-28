using Domain.Entities.ObjectValues.ProductObjectValue;
using FluentValidation;

namespace FluentValidations.Domain.Entities.ObjectValues.ProductObjectValue;

public class DataObjectValueValidator : AbstractValidator<DataObjectValue>
{
    public DataObjectValueValidator()
    {
        RuleFor(x => x.ReleaseMonth)
            .NotEmpty().WithMessage("Release month can't be empty.")
            .Length(4, 9).WithMessage("Release Month maximum 9 characters.");

        RuleFor(x => x.ReleaseYear)
            .NotEmpty().WithMessage("Release Year is required.")
            .InclusiveBetween(4,4).WithMessage("Must be a 4-digit positive integer.");
    }
}