using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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

        private IIncludableQueryable<Topic, Person> IncludeQueryable
        {
            get
            {
                return context.Topics
                    .AsNoTracking()
                    .Include(t => t.PersonTopics)
                    .ThenInclude(pt => pt.Person);
            }
        }

        public override Task<List<Topic>> GetAllAsync()
        {
            return context.Topics
                .AsNoTracking()
                .Include(t => t.PersonTopics)
                .ThenInclude(pt => pt.Person)
                .ToListAsync();
        }

        public override async Task<Topic> GetFirstWhereAsync(Expression<Func<Topic, bool>> match)
        {
            return await IncludeQueryable
                .FirstOrDefaultAsync(match);
        }
    }
}