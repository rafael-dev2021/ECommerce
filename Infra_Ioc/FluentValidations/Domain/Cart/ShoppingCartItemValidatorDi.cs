using FluentValidation;
using FluentValidations.Domain.Entities.Cart;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.FluentValidations.Domain.Cart;

public static class ShoppingCartItemValidatorDi
{
    public static IServiceCollection AddShoppingCartItemValidatorDi(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<ShoppingCartItemValidator>();
        return services;
    }
}