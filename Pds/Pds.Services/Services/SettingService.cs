using Pds.Data;
using Pds.Data.Entities;
using Pds.Services.Interfaces;

namespace Pds.Services.Services;

public class SettingService : ISettingService
{
    private readonly IUnitOfWork unitOfWork;

    public SettingService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<List<Setting>> GetSettingsAsync()
    {
        return await unitOfWork.Settings.GetAllAsync();
    }
}