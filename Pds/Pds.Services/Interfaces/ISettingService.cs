using Pds.Data.Entities;

namespace Pds.Services.Interfaces;

public interface ISettingService
{
    Task<List<Setting>> GetSettingsAsync();
}