using Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.Application;

public static class ApplicationMappingProfile
{
    public static IServiceCollection AddApplicationMappingProfile(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingTheCategoryProfile));
        services.AddAutoMapper(typeof(MappingTheProductProfile));
        services.AddAutoMapper(typeof(MappingTheReviewProfile));
        services.AddAutoMapper(typeof(MappingTheShoppingCartProfile));
        services.AddAutoMapper(typeof(MappingTheOrderProfile));
        services.AddAutoMapper(typeof(MappingThePaymentProfile));
        services.AddAutoMapper(typeof(MappingTheDeliveriesProfile));
        return services;
    }
}