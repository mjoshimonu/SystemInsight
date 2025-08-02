using Microsoft.Extensions.DependencyInjection;
using SystemInsight.Domain.Interfaces;
using SystemInsight.Infrastructure.Services;

namespace SystemInsight.Infrastructure.DependencyInjection;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<ISystemInfoService, SystemInfoService>();
        return services;
    }
}