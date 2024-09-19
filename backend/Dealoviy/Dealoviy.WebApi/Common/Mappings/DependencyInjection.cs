using Mapster;
using MapsterMapper;

namespace Dealoviy.WebApi.Common.Mappings;

public static class DependencyInjection
{
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        
        var webApiAssembly = typeof(Dealoviy.WebApi.DependencyInjection).Assembly;
        var applicationAssembly = typeof(Dealoviy.Application.DependencyInjection).Assembly;
        
        config.Scan(webApiAssembly, applicationAssembly);

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        return services;
    }
}