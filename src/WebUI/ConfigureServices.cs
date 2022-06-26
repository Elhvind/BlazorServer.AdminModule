using Application.Common.Interfaces;
using Infrastructure.Persistence.Migrations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using WebUI.Areas.Identity;
using WebUI.Services;

namespace WebUI;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddSingleton<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        services
            .AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddRazorPages();

        services.AddServerSideBlazor();

        services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

        return services;
    }
}
