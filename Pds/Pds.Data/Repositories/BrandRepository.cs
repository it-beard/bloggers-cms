using Microsoft.EntityFrameworkCore;
using Pds.Data.Entities;
using Pds.Data.Repositories.Interfaces;
using Pds.Services.Models.Brand;

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

    public async Task<BrandAdditionalInfoModel> GetAdditionalInfoAsync(Guid brandId)
    {
        var result = await context.Brands
            .Select(b => new BrandAdditionalInfoModel
            {
                PersonsCount = context.Gifts
                    .Count(b => b.BrandId == brandId),
                ContentsCount = context.Contents
                    .Count(b => b.BrandId == brandId),
                GiftsCount = context.Gifts
                    .Count(b => b.BrandId == brandId),
                CostsSum = context.Costs
                    .Where(b => b.BrandId == brandId)
                    .Sum(b => b.Value),
                BillsSum = context.Bills
                    .Where(b => b.BrandId == brandId)
                    .Sum(b => b.Value)
            }).FirstAsync();

        if (result.PersonsCount +
            result.ContentsCount +
            result.CostsSum +
            result.BillsSum +
            result.GiftsCount <= 0)
        {
            result.IsDeletable = true;
        }
        
        return result;
    }

    public async Task<bool> IsExistsByNameAsync(string name)
    {
        var brand = await context.Brands
            .FirstOrDefaultAsync(c => c.Name.ToLower().Trim() == name.ToLower().Trim());
        return brand != null;
    }
}