using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vonavulary.App.Contracts.Persistence;
using Vonavulary.Persistence.Repos;

namespace Vonavulary.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
        );

        services.AddScoped(typeof(IBaseRepo<>), typeof(BaseRepo<>));
        services.AddScoped<IWordRepo, WordRepo>();
        return services;
    }
}
