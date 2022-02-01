﻿using Ceii.Api.Data.Context;
using Ceii.Api.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ceii.Api.Data;

public static class DependencyInjection
{
    public static void AddDataLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection").BuildConnectionString(),
                b => 
                    b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
            )
        );
    }
}