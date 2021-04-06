using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pds.Data.Entities;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data.Repositories
{
    public class CostRepository : RepositoryBase<Cost>, ICostRepository
    {
        private readonly ApplicationDbContext context;
        
        public CostRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        
        public async Task<List<Cost>> GetAllOrderByDateDescAsync()
        {
            return await context.Costs
                .Include(b=>b.Content)
                .OrderByDescending(p =>p.PaidAt)
                .ToListAsync();
        }
    }
}