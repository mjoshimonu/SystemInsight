using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using SystemInsight.Domain.Interfaces;

namespace SystemInsight.API.Endpoints
{
    public static class SystemInfoEndpoints
    {
        public static void MapSystemInfoEndpoints(this WebApplication app)
        {
            app.MapGet("/api/systeminfo", async (ISystemInfoService service) =>
            {
                var info = await service.GetSystemInfoAsync();
                return Results.Ok(info);
            });
        }
    }
}