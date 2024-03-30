using Domain.Entities.Cart;
using FluentValidation;

namespace FluentValidations.Domain.Entities.Cart;

public class ShoppingCartItemValidator : AbstractValidator<ShoppingCartItem>
{
    public ShoppingCartItemValidator()
    {
        RuleFor(x=>x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
    }
}