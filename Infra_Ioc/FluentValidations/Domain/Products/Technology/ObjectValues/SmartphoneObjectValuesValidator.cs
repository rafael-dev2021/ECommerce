using FluentValidation;
using FluentValidations.Domain.Entities.Products.Technology.Smartphones.ObjectValues;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.FluentValidations.Domain.Products.Technology.ObjectValues;

public static class SmartphoneObjectValuesValidator
{
    public static IServiceCollection AddSmartphoneObjectValuesValidator(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<BatteryObjectValueValidator>();
        services.AddValidatorsFromAssemblyContaining<CameraObjectValueValidator>();
        services.AddValidatorsFromAssemblyContaining<DimensionObjectValueValidator>();
        services.AddValidatorsFromAssemblyContaining<DisplayObjectValueValidator>();
        services.AddValidatorsFromAssemblyContaining<FeatureObjectValueValidator>();
        services.AddValidatorsFromAssemblyContaining<PlatformObjectValueValidator>();
        services.AddValidatorsFromAssemblyContaining<StorageObjectValueValidator>();
        return services;
    }
}