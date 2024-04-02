using FluentValidation;
using FluentValidations.Domain.Entities.Reviews;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.FluentValidations.Domain.Reviews;

public static class ReviewValidatorDi
{
    public static IServiceCollection AddReviewValidatorDi(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<ReviewValidator>();
        return services;
    }
}