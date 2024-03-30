using Domain.Identity;
using FluentValidation;

namespace FluentValidations.Domain.Identity;

public class SeedUserUpdateValidator: AbstractValidator<SeedUserUpdate>
{
    public SeedUserUpdateValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name cannot be empty.")
            .MaximumLength(50).WithMessage("First name must have a maximum length of 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name cannot be empty.")
            .MaximumLength(50).WithMessage("Last name must have a maximum length of 50 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email cannot be empty.")
            .EmailAddress().WithMessage("Invalid email address format.")
            .MaximumLength(50).WithMessage("Email must have a maximum length of 50 characters.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone cannot be empty.")
            .MaximumLength(16).WithMessage("Phone must have a maximum length of 16 characters.");

        RuleFor(x => x.Ssn)
            .NotEmpty().WithMessage("SSN cannot be empty.")
            .MaximumLength(11).WithMessage("SSN must have a maximum length of 11 characters.")
            .Matches(@"^\d{9}$").WithMessage("SSN must be a 9-digit number.");

        RuleFor(x => x.BirthDate)
            .NotEmpty().WithMessage("Birth date cannot be empty.");

        RuleFor(x => x.IsSubscribedToNewsletter)
            .NotEqual(true).When(x => x.IsSubscribedToNewsletter)
            .WithMessage("You must agree to the newsletter.");
    }
}