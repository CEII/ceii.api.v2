using System.Reflection;
using Ceii.Api.Application.Contracts.Activities;
using Ceii.Api.Application.Contracts.Profiles;
using Ceii.Api.Application.Contracts.Users;
using Ceii.Api.Application.Repositories;
using Ceii.Api.Application.Services.Profiles;
using Ceii.Api.Application.Services.Users;
using Ceii.Api.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ceii.Api.Application;

public static class DependencyInjection
{
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IProfileRepository, ProfileRepository>();
        services.AddTransient<IActivityRepository, ActivityRepository>();
    }
    
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration, string? envDb)
    {
        services.AddAutoMapper(Assembly.Load("Ceii.Api.Application"));
        services.AddDataLayer(configuration, envDb);

        services.AddRepositories();

        services.AddTransient<UserService>();
        services.AddTransient<ProfileService>();
        services.AddTransient<ActivityRepository>();

    }
}