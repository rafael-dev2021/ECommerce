using Domain.Identity;
using FluentValidation;

namespace FluentValidations.Domain.Identity;

public class RegistrationResultValidator : AbstractValidator<RegistrationResult>
{
    public RegistrationResultValidator()
    {
        RuleFor(x => x.IsRegistered)
            .NotEqual(false).WithMessage("Registration failed.")
            .When(x => !x.IsRegistered);

        RuleFor(x => x.ErrorMessage)
            .NotEmpty().WithMessage("Error message cannot be empty if registration failed.")
            .When(x => !x.IsRegistered);

        RuleFor(x => x.ErrorMessage)
            .Empty().WithMessage("Error message must be empty if registration succeeded.")
            .When(x => x.IsRegistered);
    }
}
