using Infra_Ioc.Domain;
using Infra_Ioc.Domain.Products.Fashion;
using Infra_Ioc.Domain.Products.Technology;
using Infra_Ioc.Identity;
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