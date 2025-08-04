using System.Management;
using SystemInsight.Domain.Interfaces;
using SystemInsight.Domain.Models;

namespace SystemInsight.Infrastructure.Services
{
    public class MemoryInfoService : IMemoryInfoService
    {
        public Task<SystemMemoryInfo> GetMemoryInfoAsync()
        {
            ulong totalPhysical = 0, freePhysical = 0, totalVirtual = 0, freeVirtual = 0;

            using var searcher = new ManagementObjectSearcher("SELECT TotalVisibleMemorySize, FreePhysicalMemory, TotalVirtualMemorySize, FreeVirtualMemory FROM Win32_OperatingSystem");

            foreach (ManagementObject obj in searcher.Get())
            {
                totalPhysical = (ulong)obj["TotalVisibleMemorySize"];
                freePhysical = (ulong)obj["FreePhysicalMemory"];
                totalVirtual = (ulong)obj["TotalVirtualMemorySize"];
                freeVirtual = (ulong)obj["FreeVirtualMemory"];
            }

            return Task.FromResult(new SystemMemoryInfo
            {
                TotalPhysicalMemory = totalPhysical,
                FreePhysicalMemory = freePhysical,
                TotalVirtualMemory = totalVirtual,
                FreeVirtualMemory = freeVirtual
            });
        }
    }
}