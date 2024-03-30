using Domain.Entities.Payments;
using FluentValidation;

namespace FluentValidations.Domain.Entities.Payments;


public class CardValidator<T> : AbstractValidator<T> where T : Card
{
    public CardValidator()
    {
        RuleFor(x => x.CardNumber)
            .NotEmpty().WithMessage("Card number cannot be empty.")
            .MaximumLength(19).WithMessage("Card Number must have a maximum length of 19 characters.")
            .Matches(@"^\d{16}$").WithMessage("Card number must be a 16-digit number.");

        RuleFor(x => x.CardHolderName)
            .NotEmpty().WithMessage("Card holder name cannot be empty.")
            .MaximumLength(50).WithMessage("Card holder name must have a maximum length of 50 characters.");

        RuleFor(x => x.CardExpirationDate)
            .NotEmpty().WithMessage("Card expiration date cannot be empty.")
            .MaximumLength(5).WithMessage("Card expiration Date must have a maximum length of 5 characters.")
            .Matches(@"^(0[1-9]|1[0-2])\/\d{2}$").WithMessage("Invalid card expiration date format. Use MM/YY.");

        RuleFor(x => x.CardCvv)
            .NotEmpty().WithMessage("Card CVV cannot be empty.")
            .MaximumLength(4).WithMessage("Card cvv must have a maximum length of 4 characters.")
            .Matches(@"^\d{3}$").WithMessage("Card CVV must be a 3-digit number.");

        RuleFor(x => x.Ssn)
            .NotEmpty().WithMessage("SSN cannot be empty.")
            .MaximumLength(11).WithMessage("Ssn must have a maximum length of 11 characters.")
            .Matches(@"^\d{9}$").WithMessage("SSN must be a 9-digit number.");
    }
}
