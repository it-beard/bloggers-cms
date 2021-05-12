using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pds.Data.Entities;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data.Repositories
{
    public class TopicRepository : RepositoryBase<Topic>, ITopicRepository
    {
        private readonly ApplicationDbContext context;

        public TopicRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        private IQueryable<Topic> IncludeQueryable =>
            context.Topics
                .AsNoTracking()
                .Include(t => t.Persons);

        public async Task<Topic> GetFirstWithPeopleAsync(Expression<Func<Topic, bool>> match)
        {
            return await IncludeQueryable
                .FirstOrDefaultAsync(match);
        }
        
        public async Task<List<Topic>> GetAllFullAsync()
        {
            return await context.Topics
                .Include(p=>p.Persons)
                .ToListAsync();
        }
    }
}