using Microsoft.EntityFrameworkCore;
using Pds.Data.Entities;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data.Repositories;

public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
{
    private readonly ApplicationDbContext context;
        
    public BrandRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }    
    
    public async Task<List<Brand>> GetAllAsync()
    {
        return await context.Brands
            .ToListAsync();
    }
    
    public async Task<int> GetPersonsCountAsync(Guid brandId)
    {
        return await context.Brands
            .Where(b => b.Id == brandId)
            .Include(b => b.Persons)
            .Select(b => b.Persons)
            .CountAsync();
    }
    
    public async Task<int> GetContentsCountAsync(Guid brandId)
    {
        return await context.Contents
            .Where(b => b.BrandId == brandId)
            .CountAsync();
    }
    
    public async Task<decimal> GetCostsSumAsync(Guid brandId)
    {
        return await context.Costs
            .Where(b => b.BrandId == brandId)
            .SumAsync(b => b.Value);
    }
    
    public async Task<decimal> GetBillsSumAsync(Guid brandId)
    {
        return await context.Bills
            .Where(b => b.BrandId == brandId)
            .SumAsync(b => b.Value);
    }    
    
    public async Task<int> GetGiftsCountAsync(Guid brandId)
    {
        return await context.Gifts
            .Where(b => b.BrandId == brandId)
            .CountAsync();
    }
}