using System.Reflection;
using Ceii.Api.Application.Contracts.Developers;
using Ceii.Api.Application.Contracts.Users;
using Ceii.Api.Application.Repositories;
using Ceii.Api.Application.Services.Developers;
using Ceii.Api.Application.Services.Users;
using Ceii.Api.Data;
using Ceii.Api.Data.Entities.Developer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ceii.Api.Application;

public static class DependencyInjection
{
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IDeveloperRepository, DeveloperRepository>();
    }
    
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.Load("Ceii.Api.Application"));
        services.AddDataLayer(configuration);

        services.AddRepositories();

        services.AddTransient<UserService>();
        services.AddTransient<DeveloperService>();
    }
}