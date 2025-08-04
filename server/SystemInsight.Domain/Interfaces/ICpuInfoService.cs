using System.Threading.Tasks;
using SystemInsight.Domain.Models;

namespace SystemInsight.Domain.Interfaces
{
    public interface ICpuInfoService
    {
        Task<CpuInfo> GetCpuInfoAsync();
    }
}