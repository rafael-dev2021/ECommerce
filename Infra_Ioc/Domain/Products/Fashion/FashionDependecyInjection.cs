using Domain.Interfaces.Products.Fashion;
using Infra_Data.Repositories.Products.Fashion;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.Products.Fashion;

public static class FashionDependecyInjection
{
    public static IServiceCollection AddFashionDependecyInjection(this IServiceCollection services)
    {
        services.AddScoped<IShoesRepository, ShoesRepository>();
        services.AddScoped<IShirtRepository, ShirtRepository>();

        return services;
    }
}