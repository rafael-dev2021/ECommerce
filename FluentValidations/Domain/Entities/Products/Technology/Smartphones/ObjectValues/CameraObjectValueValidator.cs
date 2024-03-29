using Domain.Entities.Products.Technology.Smartphones.ObjectValues;
using FluentValidation;

namespace FluentValidations.Domain.Entities.Products.Technology.Smartphones.ObjectValues;

public class CameraObjectValueValidator : AbstractValidator<CameraObjectValue>
{
    public CameraObjectValueValidator()
    {
        RuleFor(x => x.MainCameraSpec)
            .NotEmpty().WithMessage("Main camera specification cannot be empty.")
            .MaximumLength(15).WithMessage("Main camera specification must have a maximum length of 15 characters.");

        RuleFor(x => x.MainCameraFeature)
            .NotEmpty().WithMessage("Main camera feature cannot be empty.")
            .MaximumLength(50).WithMessage("Main camera feature must have a maximum length of 50 characters.");

        RuleFor(x => x.SelfieCameraSpec)
            .NotEmpty().WithMessage("Selfie camera specification cannot be empty.")
            .MaximumLength(15).WithMessage("Selfie camera specification must have a maximum length of 15 characters.");

        RuleFor(x => x.SelfieCameraFeature)
            .NotEmpty().WithMessage("Selfie camera feature cannot be empty.")
            .MaximumLength(100).WithMessage("Selfie camera feature must have a maximum length of 100 characters.");
    }
}