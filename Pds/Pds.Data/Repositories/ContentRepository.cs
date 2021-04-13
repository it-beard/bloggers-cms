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
                .OrderByDescending(p =>p.ReleaseDate)
                .ThenBy(p=>p.Title)
                .ToListAsync();
        }

        public async Task<List<Content>> GetAllFullAsync()
        {
            return await context.Contents
                .Include(p => p.Bill)
                .ThenInclude(p => p.Client)
                .Include(p => p.Brand)
                .Include(p => p.Person)
                .ThenInclude(p => p.Resources)
                .Include(p => p.Costs)
                .OrderByDescending(p =>p.ReleaseDate)
                .ThenBy(p=>p.Title)
                .ToListAsync();
        }
        
        public async Task<Content> GetByIdWithBillAsync(Guid contentId)
        {
            return await context.Contents
                .Include(p => p.Bill)
                .FirstOrDefaultAsync(p => p.Id == contentId);
        }
        
        public async Task<Content> GetByIdFullAsync(Guid contentId)
        {
            return await context.Contents
                .Include(p => p.Bill)
                .ThenInclude(p => p.Client)
                .Include(p => p.Brand)
                .Include(p => p.Person)
                .ThenInclude(p => p.Resources)
                .Include(p => p.Costs)
                .FirstOrDefaultAsync(p => p.Id == contentId);
        }
        
        public async Task<List<Content>> GetAllOrderByReleaseDateDescAsync()
        {
            return await context.Contents
                .OrderByDescending(p =>p.ReleaseDate)
                .ToListAsync();
        }
    }
}