using System.Reflection;
using Application.Interfaces;
using Application.Services.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.Application;

public static class EntitiesServicesDependecyInjection
{
    public static IServiceCollection AddEntitiesServicesDependecyInjection(this IServiceCollection services)
    {
        services.AddScoped<IProductDtoService, ProductDtoService>();

        var applicationAssembly = AppDomain.CurrentDomain.Load("Application");
        services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), applicationAssembly);
        });

        return services;
    }
}