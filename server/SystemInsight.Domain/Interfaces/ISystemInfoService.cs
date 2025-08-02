using SystemInsight.Domain.Models;

namespace SystemInsight.Domain.Interfaces;

public interface ISystemInfoService
{
      Task<SystemInfoDto> GetSystemInfoAsync();
}