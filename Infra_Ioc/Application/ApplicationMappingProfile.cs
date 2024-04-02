using Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.Application;

public static class ApplicationMappingProfile
{
    public static IServiceCollection AddApplicationMappingProfile(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingTheProductProfile));
        return services;
    }
}