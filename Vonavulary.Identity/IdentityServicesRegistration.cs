using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Vonavulary.App.Contracts.Identity;
using Vonavulary.App.Models.Identity;
using Vonavulary.Identity.Models;
using Vonavulary.Identity.Services;

namespace Vonavulary.Identity;

public static class IdentityServicesRegistration
{
    public static IServiceCollection AddIdentityServices(
        this IServiceCollection services,
        IConfiguration config
    )
    {
        services.Configure<JwtSettings>(config.GetSection("JwtSettings"));

        services
            .AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<VonavularyIdentityDbContext>()
            .AddDefaultTokenProviders();

        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IUserService, UserService>();

        services.AddDbContext<VonavularyIdentityDbContext>(opts =>
            opts.UseNpgsql(config.GetConnectionString("DefaultConnection"))
        );

        return services;
    }
}
