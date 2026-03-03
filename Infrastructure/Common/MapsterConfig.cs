using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Common;

public static class MapsterConfig
{
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Default.IgnoreNullValues(false);

        return services;
    }
}