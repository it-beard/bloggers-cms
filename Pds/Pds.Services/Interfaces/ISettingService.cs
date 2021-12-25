using Pds.Data.Entities;
using Pds.Services.Models.Setting;

namespace Pds.Services.Interfaces;

public interface ISettingService
{
    Task<List<Setting>> GetAllAsync();
    Task<Setting> GetAsync(Guid settingId);
    Task<Guid> EditAsync(EditSettingModel model);
}