using System.Text;
using CogLog.App.Constants;
using CogLog.App.Contracts.Identity;
using CogLog.App.Models.Identity;
using CogLog.Identity.Models;
using CogLog.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CogLog.Identity;

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
            .AddEntityFrameworkStores<CogLogIdentityDbContext>()
            .AddDefaultTokenProviders();

        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IUserService, UserService>();

        services.AddDbContext<CogLogIdentityDbContext>(opts =>
            opts.UseSqlServer(config.GetConnectionString("DefaultConnection"))
        );

        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = config["JwtSettings:Issuer"],
                    ValidAudience = config["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)
                    ),
                };
            });

        return services;
    }
}
