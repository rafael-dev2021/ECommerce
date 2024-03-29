using Domain.Entities.Products.Technology.Games.ObjectValues;
using FluentValidation;

namespace FluentValidations.Domain.Entities.Products.Technology.Games.ObjectValues;

public class GeneralFeaturesObjectValueValidator: AbstractValidator<GeneralFeaturesObjectValue>
{
    public GeneralFeaturesObjectValueValidator()
    {
        RuleFor(x => x.Collection)
            .NotEmpty().WithMessage("Collection cannot be empty.")
            .MaximumLength(25).WithMessage("Collection must have a maximum length of 25 characters.");

        RuleFor(x => x.Saga)
            .NotEmpty().WithMessage("Saga cannot be empty.")
            .MaximumLength(40).WithMessage("Saga must have a maximum length of 40 characters.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title cannot be empty.")
            .MaximumLength(50).WithMessage("Title must have a maximum length of 50 characters.");

        RuleFor(x => x.Edition)
            .NotEmpty().WithMessage("Edition cannot be empty.")
            .MaximumLength(25).WithMessage("Edition must have a maximum length of 25 characters.");

        RuleFor(x => x.Platform)
            .NotEmpty().WithMessage("Platform cannot be empty.")
            .MaximumLength(15).WithMessage("Platform must have a maximum length of 15 characters.");

        RuleFor(x => x.Developers)
            .NotEmpty().WithMessage("Developers cannot be empty.")
            .MaximumLength(40).WithMessage("Developers must have a maximum length of 40 characters.");

        RuleFor(x => x.Publishers)
            .NotEmpty().WithMessage("Publishers cannot be empty.")
            .MaximumLength(15).WithMessage("Publishers must have a maximum length of 15 characters.");

        RuleFor(x => x.GameRating)
            .NotEmpty().WithMessage("Game rating cannot be empty.")
            .InclusiveBetween('A', 'Z').WithMessage("Game rating must be a valid uppercase letter (A-Z).");
    }
}