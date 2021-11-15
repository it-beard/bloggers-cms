using Microsoft.EntityFrameworkCore;
using Pds.Core.Enums;
using Pds.Data.Entities;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data.Repositories;

public class GiftRepository : RepositoryBase<Gift>, IGiftRepository
{
    private readonly ApplicationDbContext context;
        
    public GiftRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }
     
    public async Task<List<Gift>> GetAllFullAsync()
    {
        return await context.Gifts
            .Include(b=>b.Content)
            .Include(b=>b.Brand)
            .OrderByDescending(p =>p.CreatedAt)
            .ToListAsync();
    }

    public async Task<Gift> GetFullByIdAsync(Guid giftId)
    {
        return await context.Gifts
            .Include(c => c.Content)
            .Include(c => c.Brand)
            .FirstOrDefaultAsync(c => c.Id == giftId);
    }
}