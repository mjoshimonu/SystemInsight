using Microsoft.AspNetCore.Mvc;
using SystemInsight.Domain.Interfaces;

namespace SystemInsight.API.Endpoints
{
    public static class SystemInfoEndpoints
    {
        public static void MapSystemInfoEndpoints(this WebApplication app)
        {
            app.MapGet("/system/info", async ([FromServices] ISystemInfoService service) =>
            {
                var info = await service.GetSystemInfoAsync();
                return Results.Ok(info);
            })
            .WithName("GetSystemInfo")
            .WithTags("System Info");
        }
    }
}