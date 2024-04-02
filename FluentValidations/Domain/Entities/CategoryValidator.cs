using Domain.Entities;
using FluentValidation;

namespace FluentValidations.Domain.Entities;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty.")
            .MaximumLength(50).WithMessage("Name cannot be more than 50 characters.");

        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Image url cannot be empty.")
            .MaximumLength(500).WithMessage("Image url cannot be more than 500 characters.");
        
        RuleFor(x => x.IsActive)
            .NotEqual(true).When(x => x.IsActive)
            .WithMessage("The category cannot be active.");
    }
}