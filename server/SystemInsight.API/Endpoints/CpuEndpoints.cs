using Microsoft.AspNetCore.Mvc;
using SystemInsight.Domain.Interfaces;

namespace SystemInsight.API.Endpoints;

public static class CpuEndpoints
{
    public static void MapCpuEndpoints(this WebApplication app)
    {
        app.MapGet("/system/cpu", async ([FromServices]ICpuInfoService service) =>
        {
            var info = await service.GetCpuInfoAsync();
            return Results.Ok(info);
        })
        .WithName("GetCpuInfo")
        .WithTags("CPU Info");
    }
}
