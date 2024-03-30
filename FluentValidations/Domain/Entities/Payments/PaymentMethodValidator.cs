using Domain.Entities.Payments;
using FluentValidation;

namespace FluentValidations.Domain.Entities.Payments;

public class PaymentMethodValidator<T> : AbstractValidator<T> where T : PaymentMethod
{
    public PaymentMethodValidator()
    {
        RuleFor(x => x.Ssn)
            .NotEmpty().WithMessage("SSN cannot be empty.")
            .MaximumLength(11).WithMessage("SSN must have a maximum length of 11 characters.")
            .Matches(@"^\d{9}$").WithMessage("SSN must be a 9-digit number.");

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than zero.");
    }
}