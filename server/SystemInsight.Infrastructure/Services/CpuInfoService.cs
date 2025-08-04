using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Management;
using SystemInsight.Domain.Models;
using SystemInsight.Domain.Interfaces;


namespace SystemInsight.Infrastructure.Services
{
    public class CpuInfoService: ICpuInfoService
    {
        public async Task<CpuInfo> GetCpuInfoAsync()
        {
            return await Task.Run(() =>
            {
                var cpuInfo = new CpuInfo
                {
                    Name = GetProcessorName(),
                    NumberOfCores = GetNumberOfCores(),
                    MaxClockSpeedMHz = GetMaxClockSpeedMHz()
                };

                return cpuInfo;
            });
        }

        private string GetProcessorName()
        {
            using var searcher = new ManagementObjectSearcher("select Name from Win32_Processor");
            foreach (var obj in searcher.Get())
                return obj["Name"]?.ToString() ?? "Unknown";
            return "Unknown";

        }

        private int GetNumberOfCores()
        {
            using var searcher = new ManagementObjectSearcher("select NumberOfCores from Win32_Processor");
            foreach (var obj in searcher.Get())
                return Convert.ToInt32(obj["NumberOfCores"]);
            return 0;
        }

        private int GetMaxClockSpeedMHz()
        {
            using var searcher = new ManagementObjectSearcher("select MaxClockSpeed from Win32_Processor");
            foreach (var obj in searcher.Get())
                return Convert.ToInt32(obj["MaxClockSpeed"]);
            return 0;
        }
    }
}