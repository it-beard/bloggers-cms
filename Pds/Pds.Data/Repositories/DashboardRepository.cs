using Microsoft.EntityFrameworkCore;
using Pds.Core.Enums;
using Pds.Data.Entities;
using Pds.Data.Repositories.Interfaces;
using Pds.Services.Models.Dashboard;

namespace Pds.Data.Repositories;

public class DashboardRepository : IDashboardRepository
{
    private readonly ApplicationDbContext context;
        
    public DashboardRepository(ApplicationDbContext context)
    {
        this.context = context;
    }
        
    public async Task<List<CountryStatisticsBrandModel>> GetCountriesStatisticsAsync()
    {
        var result = await context.Brands
            .Select(b => new CountryStatisticsBrandModel()
            {
                BrandName = b.Name,
                BrandId = b.Id,
                Countries = context
                    .Persons.Where(p => p.Brands.Contains(b) && p.Status != PersonStatus.Archived)
                    .GroupBy(p => p.Country)
                    .Select(p => new CountryStatisticsCountryModel()
                    {
                        CountryName = p.Key,
                        ActivePersonsCount = p.Count()
                    })
                    .ToList()
            }).ToListAsync();
        
        return result;
    }

    public async Task<Bill> GetFullByIdAsync(Guid billId)
    {
        return await context.Bills
            .Include(c => c.Content)
            .Include(c => c.Brand)
            .Include(c => c.Client)
            .FirstOrDefaultAsync(c => c.Id == billId);
    }
}