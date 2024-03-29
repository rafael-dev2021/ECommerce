using Domain.Entities.Products.Technology.Smartphones.ObjectValues;
using FluentValidation;

namespace FluentValidations.Domain.Entities.Products.Technology.Smartphones.ObjectValues;

public class StorageObjectValueValidator: AbstractValidator<StorageObjectValue>
{
    public StorageObjectValueValidator()
    {
        RuleFor(x => x.StorageGb)
            .InclusiveBetween(64, 256).WithMessage("Storage capacity must be between 64GB and 256GB.");

        RuleFor(x => x.RamGb)
            .InclusiveBetween(2, 16).WithMessage("RAM capacity must be between 2GB and 16GB.");
    }
}