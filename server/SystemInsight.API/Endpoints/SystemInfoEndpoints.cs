using SystemInsight.Domain.Interfaces;

namespace SystemInsight.API.Endpoints
{
    public class SystemInfoEndpoints : IEndpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            app.MapGet("/system/memory", GetMemoryInfo).WithName("GetMemoryInfo").WithOpenApi();
            app.MapGet("/system/cpu", GetCpuInfo).WithName("GetCpuInfo").WithOpenApi();
            app.MapGet("/system/info", GetSystemInfo).WithName("GetSystemInfo").WithOpenApi();
        }

        private static async Task<IResult> GetSystemInfo(ISystemInfoService service)
        {
            var info = await service.GetSystemInfoAsync();
            return Results.Ok(info);
        }

        private static async Task<IResult> GetMemoryInfo(IMemoryInfoService service)
        {
            var info = await service.GetMemoryInfoAsync();
            return Results.Ok(info);
        }
        private static async Task<IResult> GetCpuInfo(ICpuInfoService service)
        {
            var info = await service.GetCpuInfoAsync();
            return Results.Ok(info);
        }
    }

}