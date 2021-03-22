using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pds.Data.Entities;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data.Repositories
{
    public class ContentRepository : RepositoryBase<Content>, IContentRepository
    {
        private readonly ApplicationDbContext context;
        
        public ContentRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        
        public async Task<List<Content>> GetAllWithOrdersAsync()
        {
            return await context.Contents.Include(p=>p.Order)
                .OrderByDescending(p =>p.ReleaseDateUtc)
                .ToListAsync();
        }
    }
}