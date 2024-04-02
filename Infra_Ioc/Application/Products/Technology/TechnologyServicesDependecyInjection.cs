using Application.Interfaces.Products.Technology;
using Application.Services.Entities.Products.Technology;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.Application.Products.Technology;

public static class TechnologyServicesDependecyInjection
{
    public static IServiceCollection AddTechnologyServicesDependecyInjection(this IServiceCollection services)
    {
        services.AddScoped<IGameDtoService, GameDtoService>();
        services.AddScoped<ISmartphoneDtoService, SmartphoneDtoService>();

        return services;
    }
}