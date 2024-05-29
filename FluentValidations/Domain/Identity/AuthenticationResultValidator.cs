using Domain.Identity;
using FluentValidation;
namespace FluentValidations.Domain.Identity;
public class AuthenticationResultValidator : AbstractValidator<AuthenticationResult>
{
    public AuthenticationResultValidator()
    {
        RuleFor(x => x.IsAuthenticated)
            .NotEqual(false).WithMessage("Authentication failed.")
            .When(x => !x.IsAuthenticated);

        RuleFor(x => x.ErrorMessage)
            .NotEmpty().WithMessage("Error message cannot be empty if authentication failed.")
            .When(x => !x.IsAuthenticated);

        RuleFor(x => x.ErrorMessage)
            .Empty().WithMessage("Error message must be empty if authentication succeeded.")
            .When(x => x.IsAuthenticated);
    }
}
