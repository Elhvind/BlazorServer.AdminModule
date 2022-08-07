using BlazorStrap;
using SharedKernel.Interfaces;
using WebUI.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddBlazorStrap();

        services.AddSingleton<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        services
            .AddHealthChecks();

        services.AddRazorPages();

        services.AddServerSideBlazor();

        //services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();

        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IDateTimeOffset, DateTimeOffsetService>();

        return services;
    }
}
