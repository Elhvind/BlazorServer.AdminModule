using ApplicationCore.Common.Interfaces;
using BlazorStrap;
using Infrastructure.Identity;
using Infrastructure.Persistence.Migrations;
using Microsoft.AspNetCore.Components.Authorization;
using WebUI.Areas.Identity;
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
            .AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddRazorPages();

        services.AddServerSideBlazor();

        services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();

        return services;
    }
}
