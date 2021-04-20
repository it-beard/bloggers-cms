using System;
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
                .Include(t => t.People);

        public async Task<Topic> GetFirstWithPeople(Expression<Func<Topic, bool>> match)
        {
            return await IncludeQueryable
                .FirstOrDefaultAsync(match);
        }
    }
}