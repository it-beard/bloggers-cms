using Pds.Core.Exceptions.Setting;
using Pds.Data;
using Pds.Data.Entities;
using Pds.Services.Interfaces;
using Pds.Services.Models.Setting;

namespace Pds.Services.Services;

public class SettingService : ISettingService
{
    private readonly IUnitOfWork unitOfWork;

    public SettingService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<List<Setting>> GetAllAsync()
    {
        return await unitOfWork.Settings.GetAllAsync();
    }
    
    public async Task<Setting> GetAsync(Guid settingId)
    {
        return await unitOfWork.Settings.GetFirstWhereAsync(s=> s.Id == settingId);
    }
    
    public async Task<Guid> EditAsync(EditSettingModel model)
    {
        if (model == null)
        {
            throw new SettingEditException("Модель запроса пуста.");
        }

        var setting = await unitOfWork.Settings.GetFirstWhereAsync( s => s.Id == model.Id);

        if (setting == null)
        {
            throw new SettingEditException($"Настройка с id {model.Id} не найдена.");
        }

        setting.UpdatedAt = DateTime.UtcNow;
        setting.Value = model.Value.Trim();
        var result = await unitOfWork.Settings.UpdateAsync(setting);

        return result.Id;
    }
}