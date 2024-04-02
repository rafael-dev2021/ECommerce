using Application.Interfaces.Products.Fashion;
using Application.Services.Entities.Products.Fashion;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.Application.Products.Fashion;

public static class FashionServicesDependecyInjection
{
    public static IServiceCollection AddFashionServicesDependecyInjection(this IServiceCollection services)
    {
        services.AddScoped<IShoeDtoService, ShoesDtoService>();
        services.AddScoped<IShirtDtoService, ShirtDtoService>();

        return services;
    } 
}