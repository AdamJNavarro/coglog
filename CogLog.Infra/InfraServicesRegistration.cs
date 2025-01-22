using CogLog.App.Contracts.Logging;
using CogLog.Infra.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace CogLog.Infra;

public static class InfraServicesRegistration
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        return services;
    }
}
