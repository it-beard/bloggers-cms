using Microsoft.EntityFrameworkCore;
using Pds.Data.Entities;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data.Repositories;

public class CostRepository : RepositoryBase<Cost>, ICostRepository
{
    private readonly ApplicationDbContext context;
        
    public CostRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }

    public async Task<Cost> GetFullByIdAsync(Guid costId)
    {
        return await context.Costs
            .Include(c => c.Brand)
            .Include(c => c.Content)
            .FirstOrDefaultAsync(c => c.Id == costId);
    }

    public async Task<List<Cost>> GetAllOrderByDateDescAsync()
    {
        return await context.Costs
            .Include(b=>b.Content)
            .Include(b=>b.Brand)
            .OrderByDescending(p =>p.PaidAt)
            .ToListAsync();
    }
}