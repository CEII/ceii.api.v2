using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.SystemConsole.Themes;

namespace Ceii.Api.Core;

public static class DependencyInjection
{
    public static void AddCoreApiDependencies(this IServiceCollection services, IConfiguration configuration,
        IHostBuilder host)
    {
        services.AddLogger(configuration, host);
        services.AddAuthorization(configuration);
    }

    private static void AddLogger(this IServiceCollection services, IConfiguration configuration, IHostBuilder host)
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.WithExceptionDetails()
            .WriteTo.Console(theme: AnsiConsoleTheme.Code)
            .CreateBootstrapLogger();

        host.UseSerilog((ctx, lc) => lc
            .WriteTo.Console()
            .ReadFrom.Configuration(ctx.Configuration));

        Log.Information("Starting up");
        Log.Information("Event: Added Logger");
    }

    private static void AddAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });

        Log.Information("Event: Added Authorization and Authentication");
    }
}