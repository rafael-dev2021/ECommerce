using Domain.Entities.Deliveries;
using FluentValidation;

namespace FluentValidations.Domain.Entities.Deliveries;

public class UserDeliveryValidator: AbstractValidator<UserDelivery>
{
    public UserDeliveryValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name cannot be empty.")
            .MaximumLength(15).WithMessage("First name must have a maximum length of 15 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name cannot be empty.")
            .MaximumLength(15).WithMessage("Last name must have a maximum length of 15 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email cannot be empty.")
            .EmailAddress().WithMessage("Invalid email address format.")
            .MaximumLength(50).WithMessage("Email must have a maximum length of 50 characters.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone cannot be empty.")
            .MaximumLength(16).WithMessage("Phone must have a maximum length of 16 characters.");

        RuleFor(x => x.Ssn)
            .NotEmpty().WithMessage("SSN cannot be empty.")
            .MaximumLength(11).WithMessage("Ssn must have a maximum length of 11 characters.")
            .Matches(@"^\d{9}$").WithMessage("SSN must be a 9-digit number.");
    }
    
}