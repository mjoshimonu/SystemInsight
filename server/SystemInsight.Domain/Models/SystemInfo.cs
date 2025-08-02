namespace SystemInsight.Domain.Models;

public class SystemInfo
{
    public string TotalMemory { get; set; }
    public string AvailableMemory { get; set; }
    public string CpuUsage { get; set; }
    public List<DiskInfo> DiskUsage { get; set; }
    public string OsVersion { get; set; }
}