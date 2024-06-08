using Application.Interfaces;
using Application.Services.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Services.CalculateWeightedAverageReviews;
using Application.Services.CalculateWeightedAverageReviews.Interfaces;
using Application.Services.CountProductByPrice;
using Application.Services.CountProductByPrice.Interfaces;
using Application.Services.Discounts;
using Application.Services.Discounts.Interfaces;
using Application.Services.PriceIsHigherThan;
using Application.Services.PriceIsHigherThan.Interfaces;

namespace Infra_Ioc.Application;

public static class EntitiesServicesDependecyInjection
{
    public static IServiceCollection AddEntitiesServicesDependecyInjection(this IServiceCollection services)
    {
        services.AddScoped<ICategoryDtoService, CategoryDtoService>();
        services.AddScoped<IProductDtoService, ProductDtoService>();
        services.AddScoped<IReviewDtoService, ReviewDtoService>();
        services.AddScoped<IShoppingCartItemDtoService, ShoppingCartItemDtoService>();
        services.AddScoped<IOrderDtoService, OrderDtoService>();
        services.AddScoped<IPaymentDtoService, PaymentDtoService>();
        services.AddScoped<ICountProductsByPriceService, CountProductsByPriceService>();
        services.AddScoped<IPriceIsHigherThanService, PriceIsHigherThanService>();
        services.AddScoped<ICalculateDiscountService, CalculateDiscountService>();
        services.AddScoped<IWeightedAverageResult, WeightedAverageCalculator>();

        var applicationAssembly = AppDomain.CurrentDomain.Load("Application");
        services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), applicationAssembly);
        });

        return services;
    }
}