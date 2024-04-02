using FluentValidation;
using FluentValidations.Domain.Entities.Products.Fashion.T_Shirts.ObjectValues;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.FluentValidations.Domain.Products.Fashion.ObjectValues;

public static class ShirtObjectValuesValidator
{
    public static IServiceCollection AddShirtObjectValuesValidator(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<MainFeaturesObjectValueValidator>();
        services.AddValidatorsFromAssemblyContaining<OtherFeaturesObjectValueValidator>();
        return services;
    }
}