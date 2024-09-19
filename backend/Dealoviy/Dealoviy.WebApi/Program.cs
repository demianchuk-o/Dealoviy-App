using Dealoviy.Application;
using Dealoviy.Infrastructure;
using Dealoviy.WebApi;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration)
        .AddWebApi();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.Map("/error", (HttpContext context) =>
    {
        Exception? exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        return Results.Problem();
    });
    
    app.UseHttpsRedirection();
    
    app.UseCors(opt => opt
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .WithOrigins(builder.Configuration.GetSection("AppUrl").Get<string>()!));
    
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}