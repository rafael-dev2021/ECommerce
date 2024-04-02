using FluentValidation;
using FluentValidations.Domain.Entities.Products.Fashion.Shoes.ObjectValues;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.FluentValidations.Domain.Products.Fashion.ObjectValues;

public static class ShoeObjectValuesValidator
{
    public static IServiceCollection AddShoeObjectValuesValidator(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<MaterialObjectValueValidator>();
        return services;
    }
}