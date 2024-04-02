using Domain.Entities;
using FluentValidation;

namespace FluentValidations.Domain.Entities;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty.")
            .MaximumLength(60).WithMessage("Name cannot be more than 60 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description cannot be empty.")
            .MaximumLength(10000).WithMessage("Description cannot be more than 10000 characters.");

        RuleFor(x => x.ImagesUrl[0])
            .NotEmpty().WithMessage("Images cannot be empty.")
            .MaximumLength(800).WithMessage("Images cannot be more than 800 characters.");
        RuleFor(x => x.Stock)
            .GreaterThan(0).WithMessage("Stock must be greater than zero.");
    }
}