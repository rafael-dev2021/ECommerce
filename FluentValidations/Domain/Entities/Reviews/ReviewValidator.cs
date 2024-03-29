using Domain.Entities.Reviews;
using FluentValidation;

namespace FluentValidations.Domain.Entities.Reviews;

public class ReviewValidator: AbstractValidator<Review>
{
    public ReviewValidator()
    {
        RuleFor(x => x.Comment)
            .NotEmpty().WithMessage("Comment cannot be empty.")
            .MaximumLength(2000).WithMessage("Comment cannot be more than 2000 characters.");

        RuleFor(x => x.Image)
            .MaximumLength(250).WithMessage("Image cannot be more than 250 characters.");

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");
    }
}