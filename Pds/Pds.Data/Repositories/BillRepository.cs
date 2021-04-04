using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pds.Core.Enums;
using Pds.Data.Entities;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data.Repositories
{
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
                .Where(b => b.Status == BillStatus.Paid)
                .Include(b=>b.Content)
                .OrderByDescending(p =>p.PaidAt)
                .ToListAsync();
        }
    }
}