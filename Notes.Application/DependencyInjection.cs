using Microsoft.Extensions.DependencyInjection;
using System.Net.NetworkInformation;

namespace Notes.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Ping).Assembly));

        return services;
    }
}
