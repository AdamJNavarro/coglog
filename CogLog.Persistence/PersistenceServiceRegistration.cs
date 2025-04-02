using CogLog.App.Contracts.Persistence;
using CogLog.Persistence.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CogLog.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        );

        services.AddScoped(typeof(IBaseRepo<>), typeof(BaseRepo<>));
        services.AddScoped<IWordRepo, WordRepo>();
        services.AddScoped<IBlockRepo, BlockRepo>();
        services.AddScoped<ITopicRepo, TopicRepo>();
        services.AddScoped<ICategoryRepo, CategoryRepo>();
        services.AddScoped<ISubjectRepo, SubjectRepo>();
        services.AddScoped<ITagRepo, TagRepo>();
        return services;
    }
}
