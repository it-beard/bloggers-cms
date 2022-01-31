using Pds.Core.Enums;
using Pds.Core.Exceptions.Bill;
using Pds.Data;
using Pds.Data.Entities;
using Pds.Services.Interfaces;
using Pds.Services.Models.Bill;
using Pds.Services.Models.Dashboard;

namespace Pds.Services.Services;

public class DashboardService : IDashboardService
{
    private readonly IUnitOfWork unitOfWork;

    public DashboardService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<List<CountryStatisticsBrandModel>> GetCountriesStatisticsAsync()
    {
        return await unitOfWork.Dashboard.GetCountriesStatisticsAsync();
    }
    
    public async Task<List<MoneyStatisticsBrandModel>> GetMoneyStatisticsAsync()
    {
        return await unitOfWork.Dashboard.GetMoneyStatisticsAsync();
    }
}