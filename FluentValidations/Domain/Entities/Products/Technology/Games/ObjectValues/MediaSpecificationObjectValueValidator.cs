using Domain.Entities.Products.Technology.Games.ObjectValues;
using FluentValidation;

namespace FluentValidations.Domain.Entities.Products.Technology.Games.ObjectValues;

public class MediaSpecificationObjectValueValidator : AbstractValidator<MediaSpecificationObjectValue>
{
    public MediaSpecificationObjectValueValidator()
    { 
        RuleFor(x => x.Format)
            .NotEmpty().WithMessage("Format cannot be empty.")
            .MaximumLength(20).WithMessage("Format must have a maximum length of 20 characters.");

        RuleFor(x => x.AudioLanguages)
            .NotEmpty().WithMessage("Audio languages cannot be empty.")
            .MaximumLength(50).WithMessage("Audio languages must have a maximum length of 50 characters.");

        RuleFor(x => x.SubtitleLanguages)
            .NotEmpty().WithMessage("Subtitle languages cannot be empty.")
            .MaximumLength(30).WithMessage("Subtitle languages must have a maximum length of 30 characters.");

        RuleFor(x => x.ScreenLanguages)
            .NotEmpty().WithMessage("Screen languages cannot be empty.")
            .MaximumLength(30).WithMessage("Screen languages must have a maximum length of 30 characters.");

        RuleFor(x => x.MaximumNumberOfOfflinePlayers)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Maximum number of offline players must be greater than or equal to zero.");

        RuleFor(x => x.MaximumNumberOfOnlinePlayers)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Maximum number of online players must be greater than or equal to zero.");

        RuleFor(x => x.FileSize)
            .GreaterThanOrEqualTo(0).WithMessage("File size must be greater than or equal to zero.");

        RuleFor(x => x.IsMultiplayer)
            .Equal(true).WithMessage("Is multiplayer must be true or false.");

        RuleFor(x => x.IsOnline)
            .Equal(true).WithMessage("Is online must be true or false.");

        RuleFor(x => x.IsOffline)
            .Equal(true).WithMessage("Is offline must be true or false.");
    }
}