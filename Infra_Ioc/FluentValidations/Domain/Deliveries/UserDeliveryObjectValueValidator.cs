using FluentValidation;
using FluentValidations.Domain.Entities.Deliveries;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.FluentValidations.Domain.Deliveries;

public static class UserDeliveryObjectValueValidator
{
    public static IServiceCollection AddUserDeliveryObjectValueValidator(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<DeliveryAddressValidator>();
        services.AddValidatorsFromAssemblyContaining<UserDeliveryValidator>();
        return services;
    }
}