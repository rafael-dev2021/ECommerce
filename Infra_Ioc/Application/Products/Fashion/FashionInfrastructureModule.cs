using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.Application.Products.Fashion;

public static class FashionInfrastructureModule
{
    public static IServiceCollection AddFashionInfrastructureModule(this IServiceCollection services)
    {
        services
            .AddFashionServicesDependecyInjection()
            .AddFashionMappingProfile();
        return services;
    }
}