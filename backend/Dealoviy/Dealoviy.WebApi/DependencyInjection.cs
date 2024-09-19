using Dealoviy.WebApi.Common.Mappings;

namespace Dealoviy.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddWebApi(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddMappings();
        
        return services;
    }
}