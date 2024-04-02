using FluentValidation;
using FluentValidations.Domain.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.FluentValidations.Domain.Identity;

public static class SeedUserUpdateValidatorDi
{
    public static IServiceCollection AddSeedUserUpdateValidatorDi(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<SeedUserUpdateValidator>();
        return services;
    }
}