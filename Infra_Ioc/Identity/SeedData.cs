﻿using Domain.Interfaces.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Infra_Ioc.Identity;

public static class SeedData
{
    public static async Task SeedUsersRoles(IApplicationBuilder builder)
    {
        var scope = builder.ApplicationServices.CreateScope();
        var result = scope.ServiceProvider.GetService<ISeedUserRoleRepository>();

        if (result != null)
        {
            await result.SeedRoleAsync();
            await result.SeedUserAsync();
        }
    }
}
