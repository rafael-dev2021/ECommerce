using Application.Interfaces;
using Application.Services.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infra_Ioc.Application;

public static class EntitiesServicesDependecyInjection
{
    public static IServiceCollection AddEntitiesServicesDependecyInjection(this IServiceCollection services)
    {
        services.AddScoped<ICategoryDtoService, CategoryDtoService>();
        services.AddScoped<IProductDtoService, ProductDtoService>();
        services.AddScoped<IReviewDtoService, ReviewDtoService>();
        services.AddScoped<IShoppingCartItemDtoService, ShoppingCartItemDtoService>();

        var applicationAssembly = AppDomain.CurrentDomain.Load("Application");
        services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), applicationAssembly);
        });

        return services;
    }
}