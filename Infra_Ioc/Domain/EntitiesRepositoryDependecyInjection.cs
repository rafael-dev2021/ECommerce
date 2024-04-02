using Domain.Interfaces;
using Domain.Interfaces.Payments;
using Infra_Data.Repositories;
using Infra_Data.Repositories.Orders;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc;

public static class EntitiesRepositoryDependecyInjection
{
    public static IServiceCollection AddEntitiesRepositoryDependecyInjection(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();

        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IShoppingCartItemRepository, ShoppingCartRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();

        return services;
    }
}