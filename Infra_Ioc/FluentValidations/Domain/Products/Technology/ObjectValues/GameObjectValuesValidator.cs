using FluentValidation;
using FluentValidations.Domain.Entities.Products.Technology.Games.ObjectValues;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.FluentValidations.Domain.Products.Technology.ObjectValues;

public static class GameObjectValuesValidator
{
    public static IServiceCollection AddGameObjectValuesValidator(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<GeneralFeaturesObjectValueValidator>();
        services.AddValidatorsFromAssemblyContaining<MediaSpecificationObjectValueValidator>();
        services.AddValidatorsFromAssemblyContaining<RequirementObjectValueValidator>();
        return services;
    }
}