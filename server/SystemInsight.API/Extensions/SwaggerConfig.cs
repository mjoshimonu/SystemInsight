using Microsoft.OpenApi.Models;

namespace SystemInsight.API.Extensions;

public static class SwaggerConfig
{
    public static void AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "System Insight API",
                Version = "v1",
                Description = "Windows System Info API"
            });
        });
    }

    public static void UseSwaggerDocumentation(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "System Insight API V1");
        });
    }
}