using Application.Mappings.Products.Technology;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.Application.Products.Technology;

public static class TechnologyMappingProfile
{
    public static IServiceCollection AddTechnologyMappingProfile(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingTheGameProfile));
        services.AddAutoMapper(typeof(MappingTheSmartphoneProfile));
        return services;
    }
}