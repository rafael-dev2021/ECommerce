using Application.Mappings.Products.Fashion;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.Application.Products.Fashion;

public static class FashionMappingProfile
{
    public static IServiceCollection AddFashionMappingProfile(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingTheShoeProfile));
        services.AddAutoMapper(typeof(MappingTheShirtProfile));
        return services;
    }
}