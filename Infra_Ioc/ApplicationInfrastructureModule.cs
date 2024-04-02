
using Infra_Ioc.Application;
using Infra_Ioc.Application.Products.Fashion;
using Infra_Ioc.Application.Products.Technology;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc;

public  static class ApplicationInfrastructureModule
{
    public static IServiceCollection AddDApplicationInfrastructureModule(this IServiceCollection services)
    {
        services
            .AddEntitiesServicesDependecyInjection()
            .AddApplicationMappingProfile()
            .AddFashionInfrastructureModule()
            .AddTechnologyInfrastructureModule();
        return services;
    }
}