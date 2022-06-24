using Microsoft.EntityFrameworkCore;
using Pds.Core.Enums;
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
            .Where(b => !b.IsArchived)
            .Select(b => new CountryStatisticsBrandModel()
            {
                BrandName = b.Name,
                BrandId = b.Id,
                Countries = context.Persons
                    .Where(p => p.Brands.Contains(b) && p.Status != PersonStatus.Archived)
                    .GroupBy(p => p.Country)
                    .Where(c => !string.IsNullOrWhiteSpace(c.Key) && c.Count() > 1)
                    .OrderByDescending(c => c.Count())
                    .Select(p => new CountryStatisticsCountryModel()
                    {
                        Name = p.Key,
                        ActivePersonsCount = p.Count()
                    })
                    .OrderByDescending(b => b.ActivePersonsCount)
                    .ToList()
            }).ToListAsync();

        return result;
    }

    public async Task<List<MoneyStatisticsBrandModel>> GetMoneyStatisticsAsync()
    {
        var firstDayOfThisMonth = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
        var firstDayOfPreviousMonth = firstDayOfThisMonth.AddMonths(-1);
        var lastDayOfPreviousMonth = firstDayOfPreviousMonth.AddMonths(1).AddDays(-1);
        var firstDayOfSameMonthYearAgo = firstDayOfThisMonth.AddYears(-1);
        var lastDayOfSameMonthYearAgo = firstDayOfSameMonthYearAgo.AddMonths(1).AddDays(-1);
        
        var result = await context.Brands
            .Where(b => !b.IsArchived)
            .Select(b => new MoneyStatisticsBrandModel()
            {
                BrandName = b.Name,
                BrandId = b.Id,
                BillsSumForThisMonth = 
                    b.Bills
                        .Where(b => b.PaidAt != null && 
                                    b.PaidAt.Value.Date >= firstDayOfThisMonth && 
                                    b.PaidAt.Value.Date <= DateTime.UtcNow)
                        .Sum(b=>b.Value),
                BillsSumForPreviousMonth = 
                    b.Bills
                        .Where(b => b.PaidAt != null && 
                                    b.PaidAt.Value.Date >= firstDayOfPreviousMonth && 
                                    b.PaidAt.Value.Date <= lastDayOfPreviousMonth)
                        .Sum(b=>b.Value),
                BillsSumSameMonthYearAgo = 
                    b.Bills
                        .Where(b => b.PaidAt != null && 
                                    b.PaidAt.Value.Date >= firstDayOfSameMonthYearAgo && 
                                    b.PaidAt.Value.Date <= lastDayOfSameMonthYearAgo)
                        .Sum(b=>b.Value),
                CostsSumForThisMonth = 
                    b.Costs
                        .Where(b => b.PaidAt.Date >= firstDayOfThisMonth && 
                                    b.PaidAt.Date <= DateTime.UtcNow)
                        .Sum(b=>b.Value),
                CostsSumForPreviousMonth = 
                    b.Costs
                        .Where(b => b.PaidAt.Date >= firstDayOfPreviousMonth && 
                                    b.PaidAt.Date <= lastDayOfPreviousMonth)
                        .Sum(b=>b.Value) ,
                CostsSumSameMonthYearAgo = 
                    b.Costs
                        .Where(b => b.PaidAt.Date >= firstDayOfSameMonthYearAgo && 
                                    b.PaidAt.Date <= lastDayOfSameMonthYearAgo)
                        .Sum(b=>b.Value),
            })
            .ToListAsync();

        return result;
    }
    
    public async Task<List<ContentStatisticsBrandModel>> GetContentStatisticsAsync()
    {
        var result = await context.Brands
            .Where(b => !b.IsArchived)
            .Select(b => new ContentStatisticsBrandModel()
            {
                BrandName = b.Name,
                BrandId = b.Id,
                Contents = b
                    .Contents.Where(c => c.ReleaseDate >= DateTime.UtcNow.Date && 
                                         c.ReleaseDate <= DateTime.UtcNow.AddDays(7).Date &&
                                         c.Status != ContentStatus.Archived)
                    .Select(c => new ContentStatisticsContentModel
                    {
                        Title = c.Title,
                        Id = c.Id,
                        ReleaseDate = c.ReleaseDate,
                        SocialMediaType = c.SocialMediaType,
                        Bill = c.Bill == null ? 
                            null : 
                            new ContentStatisticsBillModel
                            {
                                PaymentStatus = c.Bill.PaymentStatus
                            }
                    })
                    .OrderBy(b => b.ReleaseDate)
                    .ToList()
            })
            .Take(7)
            .ToListAsync();

        return result;
    }
}