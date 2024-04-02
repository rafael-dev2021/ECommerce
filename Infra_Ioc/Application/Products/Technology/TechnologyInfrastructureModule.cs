using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.Application.Products.Technology;

public static class TechnologyInfrastructureModule
{
    public static IServiceCollection AddTechnologyInfrastructureModule(this IServiceCollection services)
    {
        services
            .AddTechnologyServicesDependecyInjection()
            .AddTechnologyMappingProfile();
        return services;
    }
}