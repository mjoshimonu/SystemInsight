using Microsoft.AspNetCore.Mvc;
using SystemInsight.Domain.Interfaces;

namespace SystemInsight.API.Endpoints
{
    public static  class MemoryInfoEndpoints

    {
        public static void MapMemoryInfoEndpoints(this WebApplication app)
        {
            app.MapGet("/system/memory", async ([FromServices] IMemoryInfoService service) =>
            {
                var info = await service.GetMemoryInfoAsync();
                return Results.Ok(info);
            })
            .WithName("GetMemoryInfo")
            .WithTags("Memory Info");
        }
    }
}