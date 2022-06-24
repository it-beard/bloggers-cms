using Microsoft.EntityFrameworkCore;
using Pds.Core.Enums;
using Pds.Data.Entities;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data.Repositories;

public class BillRepository : RepositoryBase<Bill>, IBillRepository
{
    private readonly ApplicationDbContext context;
        
    public BillRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }
        
    public async Task<List<Bill>> GetAllPaidOrderByDateDescAsync()
    {
        return await context.Bills
            .Where(b => b.PaymentStatus == PaymentStatus.Paid)
            .Include(b=>b.Content)
            .Include(b=>b.Brand)
            .Include(b=>b.Client)
            .Where(b => !b.Brand.IsArchived)
            .OrderByDescending(p =>p.PaidAt)
            .ToListAsync();
    }

    public async Task<Bill> GetFullByIdAsync(Guid billId)
    {
        return await context.Bills
            .Include(c => c.Content)
            .Include(c => c.Brand)
            .Include(c => c.Client)
            .Where(b => !b.Brand.IsArchived)
            .FirstOrDefaultAsync(c => c.Id == billId);
    }
}