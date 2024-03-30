using Domain.Entities.Orders;
using FluentValidation;

namespace FluentValidations.Domain.Entities.Orders;

public class OrderDetailValidator: AbstractValidator<OrderDetail>
{
    public OrderDetailValidator()
    {
        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");
    }
}