using System;
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
        
        public async Task<List<Content>> GetAllWithBillsAsync()
        {
            return await context.Contents.Include(p=>p.Bill)
                .OrderByDescending(p =>p.ReleaseDateUtc)
                .ThenBy(p=>p.Title)
                .ToListAsync();
        }

        public async Task<List<Content>> GetAllWithBillsWithClientsAsync()
        {
            return await context.Contents
                .Include(p=>p.Bill)
                .ThenInclude(p=>p.Client)
                .OrderByDescending(p =>p.ReleaseDateUtc)
                .ThenBy(p=>p.Title)
                .ToListAsync();
        }
        
        public async Task<Content> GetByIdWithBillAsync(Guid contentId)
        {
            return await context.Contents
                .Include(p => p.Bill)
                .FirstOrDefaultAsync(p => p.Id == contentId);
        }
        
        public async Task<List<Content>> GetAllOrderByCreatedAtDescAsync()
        {
            return await context.Contents
                .OrderByDescending(p =>p.CreatedAt)
                .ToListAsync();
        }
    }
}