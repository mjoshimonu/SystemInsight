namespace SystemInsight.Domain.Models;

public class SystemMemoryInfo
{
    public ulong TotalPhysicalMemory { get; set; }
    public ulong FreePhysicalMemory { get; set; }
    public ulong TotalVirtualMemory { get; set; }
    public ulong FreeVirtualMemory { get; set; }
}
