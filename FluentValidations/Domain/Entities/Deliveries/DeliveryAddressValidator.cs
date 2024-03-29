using Domain.Entities.Deliveries;
using FluentValidation;

namespace FluentValidations.Domain.Entities.Deliveries;

public class DeliveryAddressValidator: AbstractValidator<DeliveryAddress>
{
    public DeliveryAddressValidator()
    {
        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country cannot be empty.")
            .MaximumLength(30).WithMessage("Country must have a maximum length of 30 characters.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address cannot be empty.")
            .MaximumLength(60).WithMessage("Address must have a maximum length of 60 characters.");

        RuleFor(x => x.Complement)
            .MaximumLength(60).WithMessage("Complement must have a maximum length of 60 characters.");

        RuleFor(x => x.ZipCode)
            .NotEmpty().WithMessage("Zip code cannot be empty.")
            .MaximumLength(11).WithMessage("Zip code must have a maximum length of 11 characters.");

        RuleFor(x => x.State)
            .NotEmpty().WithMessage("State cannot be empty.")
            .MaximumLength(30).WithMessage("State must have a maximum length of 30 characters.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City cannot be empty.")
            .MaximumLength(30).WithMessage("City must have a maximum length of 30 characters.");

        RuleFor(x => x.Neighborhood)
            .NotEmpty().WithMessage("Neighborhood cannot be empty.")
            .MaximumLength(30).WithMessage("Neighborhood must have a maximum length of 30 characters.");
    }
    
}