using Pds.Data.Entities;
using Pds.Services.Models.Dashboard;

namespace Pds.Data.Repositories.Interfaces;

public interface IDashboardRepository
{
    Task<List<CountryStatisticsBrandModel>> GetCountriesStatisticsAsync();
}