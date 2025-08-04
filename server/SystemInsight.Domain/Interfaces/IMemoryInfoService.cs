using SystemInsight.Domain.Models;

namespace SystemInsight.Domain.Interfaces
{
    public interface IMemoryInfoService
    {
        Task<SystemMemoryInfo> GetMemoryInfoAsync();
    }
}