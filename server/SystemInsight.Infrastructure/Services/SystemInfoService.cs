using SystemInsight.Domain.Models;
using SystemInsight.Domain.Interfaces;
using System.Management;

namespace SystemInsight.Infrastructure.Services
{
    public class SystemInfoService : ISystemInfoService
    {
        public async Task<SystemInfoDto> GetSystemInfoAsync()
        {
            return await Task.Run(() =>
            {
                var info = new SystemInfoDto
                {
                    MachineName = Environment.MachineName,
                    OSVersion = Environment.OSVersion.ToString(),
                    Processor = GetProcessorName(),
                    RAM = GetTotalRAM(),
                    Storage = GetTotalStorage()
                };

                return info;
            });
        }

        private string GetProcessorName()
        {
            using var searcher = new ManagementObjectSearcher("select Name from Win32_Processor");
            foreach (var obj in searcher.Get())
                return obj["Name"]?.ToString();
            return "Unknown";
        }

        private string GetTotalRAM()
        {
            using var searcher = new ManagementObjectSearcher("SELECT TotalVisibleMemorySize FROM Win32_OperatingSystem");
            foreach (var obj in searcher.Get())
            {
                double kb = Convert.ToDouble(obj["TotalVisibleMemorySize"]);
                return $"{Math.Round(kb / 1024 / 1024, 2)} GB";
            }
            return "Unknown";
        }

        private string GetTotalStorage()
        {
            double total = 0;
            using var searcher = new ManagementObjectSearcher("SELECT Size FROM Win32_LogicalDisk WHERE DriveType=3");
            foreach (var obj in searcher.Get())
            {
                if (obj["Size"] != null)
                    total += Convert.ToDouble(obj["Size"]);
            }
            return $"{Math.Round(total / 1024 / 1024 / 1024, 2)} GB";
        }
    }
}
