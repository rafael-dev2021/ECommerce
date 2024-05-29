using FluentValidation;
using FluentValidations.Domain.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.FluentValidations.Domain.Identity;

public static class IdentityValidatorDi
{
    public static IServiceCollection AddIdentityValidatorDi(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<SeedUserUpdateValidator>();
        services.AddValidatorsFromAssemblyContaining<AuthenticationResultValidator>();
        services.AddValidatorsFromAssemblyContaining<RegistrationResultValidator>();
        return services;
    }
}