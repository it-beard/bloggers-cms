using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pds.Core.Enums;
using Pds.Core.Exceptions;
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

        public async Task<Content> GetFullByIdAsync(Guid contentId)
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
                .FirstOrDefaultAsync(p => p.Id == contentId);
        }
        
        public async Task<Content> GetByIdWithBillAsync(Guid contentId)
        {
            return await context.Contents
                .Include(p => p.Bill)
                .FirstOrDefaultAsync(p => p.Id == contentId);
        }
        
        public async Task<Content> GetByIdWithBillWithCostsAsync(Guid contentId)
        {
            return await context.Contents
                .Include(p => p.Bill)
                .Include(p => p.Costs)
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

        public async Task<Content> FullUpdateAsync(Content content)
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var oldBill = context.Bills.FirstOrDefault(b => b.Id == content.BillId);
                await transaction.CreateSavepointAsync("BeforeUpdateContent");
                if (content.Bill != null && oldBill != null)
                {
                    context.Bills.Update(content.Bill);
                    await context.SaveChangesAsync();
                }
                else if (content.Bill != null && oldBill == null)
                {
                    content.BillId = content.Bill.Id;
                    context.Bills.Add(content.Bill);
                    await context.SaveChangesAsync();
                }
                else if (content.Bill == null && oldBill != null)
                {
                    content.BillId = null;
                    context.Bills.Remove(oldBill);
                    await context.SaveChangesAsync();
                }

                context.Contents.Update(content);
                await context.SaveChangesAsync();

                await transaction.CommitAsync();
                return content;
            }
            catch (Exception e)
            {
                await transaction.RollbackToSavepointAsync("BeforeUpdateContent");
                throw new RepositoryException(e.Message, e.InnerException, typeof(Content).ToString());
                // TODO: logging need to be implemented here
            }
        }
        
        public async Task FullDeleteAsync(Content content)
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                await transaction.CreateSavepointAsync("BeforeDeleteContent");

                context.Contents.Remove(content);
                await context.SaveChangesAsync();
                if (content.Bill != null)
                {
                    context.Bills.Remove(content.Bill);
                    await context.SaveChangesAsync();
                }
                if (content.Costs.Count > 0)
                {
                    foreach (var cost in content.Costs)
                    {
                        context.Costs.Remove(cost);
                        await context.SaveChangesAsync();
                    }
                }

                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                await transaction.RollbackToSavepointAsync("BeforeDeleteContent");
                throw new RepositoryException(e.Message, e.InnerException, typeof(Content).ToString());
                // TODO: logging need to be implemented here
            }
        }

        public async Task FullArchiveAsync(Content content)
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                await transaction.CreateSavepointAsync("BeforeArchiveContent");

                content.Status = ContentStatus.Archived;
                content.UpdatedAt = DateTime.UtcNow;
                context.Contents.Update(content);
                await context.SaveChangesAsync();

                if (content.Costs.Count > 0)
                {
                    foreach (var cost in content.Costs)
                    {
                        cost.Status = CostStatus.Archived;
                        cost.UpdatedAt = DateTime.UtcNow;
                        context.Costs.Update(cost);
                        await context.SaveChangesAsync();
                    } 
                }
                
                if (content.Bill != null)
                {
                    content.Bill.Status = BillStatus.Archived;
                    content.Bill.UpdatedAt = DateTime.UtcNow;
                    context.Bills.Update(content.Bill);
                    await context.SaveChangesAsync();
                }

                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                await transaction.RollbackToSavepointAsync("BeforeArchiveContent");
                throw new RepositoryException(e.Message, e.InnerException, typeof(Content).ToString());
                // TODO: logging need to be implemented here
            }
        }
    }
}