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
    
    public async Task<List<Brand>> GetAllFullAsync()
    {
        return await context.Brands
            .Include(c => c.Bills)
            .Include(c => c.Contents)
            .Include(c => c.Persons)
            .Include(c => c.Costs)
            .Include(c => c.Gifts)
            .ToListAsync();
    }
}