using Infra_Ioc.Identity;
using Infra_Ioc.Products.Fashion;
using Infra_Ioc.Products.Technology;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc;

public static class DomainInfrastructureModule
{
    public static IServiceCollection AddDomainInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDataBaseDependecyInjection(configuration)
            .AddEntitiesRepositoryDependecyInjection()
            .AddTechnologyDependecyInjection()
            .AddFashionDependecyInjection()
            .AddIdentityRulesDependecyInjection();
        return services;
    }
}