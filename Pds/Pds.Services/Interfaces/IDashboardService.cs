using Pds.Data.Entities;
using Pds.Services.Models.Bill;
using Pds.Services.Models.Dashboard;

namespace Pds.Services.Interfaces;

public interface IDashboardService
{
    Task<List<CountryStatisticsBrandModel>> GetCountriesStatisticsAsync();
}