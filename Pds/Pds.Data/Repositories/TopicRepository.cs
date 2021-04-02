using System.Collections.Generic;
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

        public override Task<List<Topic>> GetAllAsync()
        {
            return context.Topics.AsNoTracking().Include(t => t.PersonTopics).ThenInclude(pt => pt.Person)
                .ToListAsync();
        }
    }
}