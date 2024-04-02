using FluentValidation;
using FluentValidations.Domain.Entities.ObjectValues.ProductObjectValue;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.FluentValidations.Domain.ObjectValues;

public static class ProductObjectValueValidator
{
    public static IServiceCollection AddProductObjectValueValidator(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<DataObjectValueValidator>();
        services.AddValidatorsFromAssemblyContaining<FlagsObjectValueValidator>();
        services.AddValidatorsFromAssemblyContaining<PriceObjectValueValidator>();
        services.AddValidatorsFromAssemblyContaining<SpecificationObjectValueValidator>();
        services.AddValidatorsFromAssemblyContaining<WarrantyObjectValueValidator>();
        services.AddValidatorsFromAssemblyContaining<CommonPropertiesValidator>();
        return services;
    }
}