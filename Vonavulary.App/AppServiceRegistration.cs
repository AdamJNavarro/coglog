using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Vonavulary.App;

public static class AppServiceRegistration
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
        );
        return services;
    }
}
