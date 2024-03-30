using Domain.Entities.Orders;
using FluentValidation;

namespace FluentValidations.Domain.Entities.Orders;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(x => x.TotalOrder)
            .GreaterThan(0).WithMessage("Total order must be greater than zero.");

        RuleFor(x => x.TotalItemsOrder)
            .GreaterThan(0).WithMessage("Total items order must be greater than zero.");

        RuleFor(x => x.ConfirmedOrder)
            .NotEmpty().WithMessage("Confirmed order date cannot be empty.");

        RuleFor(x => x.DispatchedOrder)
            .NotEmpty().WithMessage("Dispatched order date cannot be empty.");

        RuleFor(x => x.RequestReceived)
            .NotEmpty().WithMessage("Request received date cannot be empty.");
    }
}