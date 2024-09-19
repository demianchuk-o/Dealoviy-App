using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Dealoviy.Application.Common.Interfaces.Authentication;
using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Application.Common.Interfaces.Security;
using Dealoviy.Application.Common.Interfaces.Services;
using Dealoviy.Infrastructure.Authentication.Security;
using Dealoviy.Infrastructure.Authentication.Tokens;
using Dealoviy.Infrastructure.Persistence;
using Dealoviy.Infrastructure.Persistence.Repositories;
using Dealoviy.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Dealoviy.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddServices()
            .AddPersistence(configuration)
            .AddAuth(configuration);
        
        return services;
    }
    
    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
    
    private static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<DealoviyDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
            
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRegionRepository, RegionRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<IContractorProfileRepository, ContractorProfileRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IRequestRepository, RequestRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        return services;
    }
    
    private static IServiceCollection AddAuth(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);
        services.AddSingleton(Options.Create(jwtSettings));
        
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret))
                };
            });
        
        services.AddSecurity();
        return services;
    }
    
    private static IServiceCollection AddSecurity(this IServiceCollection services)
    {
        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        return services;
    }
}