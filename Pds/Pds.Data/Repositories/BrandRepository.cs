﻿using Microsoft.EntityFrameworkCore;
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

    public async Task<BrandAdditionalInfoModel> GetAdditionalInfoAsync(Guid brandId)
    {
        var result = await context.Brands
            .Where(b => b.Id == brandId)
            .Select(b => new BrandAdditionalInfoModel
            {
                PersonsCount = b.Persons.Count(), 
                ContentsCount = context.Contents.Count(c => c.BrandId == brandId),
                GiftsCount = context.Gifts.Count(g => g.BrandId == brandId),
                CostsSum = context.Costs.Where(c => c.BrandId == brandId).Sum(c => c.Value),
                BillsSum = context.Bills.Where(b => b.BrandId == brandId).Sum(b => b.Value)
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
    
    public async Task<List<Brand>> GetAllNotArchived()
    {
        var result = await context.Brands
            .Where(b => !b.IsArchived)
            .ToListAsync();

        return result;
    }

    public async Task<bool> IsExistsByNameAsync(string name)
    {
        var brand = await context.Brands
            .FirstOrDefaultAsync(c => c.Name.ToLower().Trim() == name.ToLower().Trim());
        return brand != null;
    }
}