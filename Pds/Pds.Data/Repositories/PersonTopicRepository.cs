using Pds.Data.Entities;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data.Repositories
{
    public class PersonTopicRepository : RepositoryBase<PersonTopic>, IPersonTopicRepository
    {
        public PersonTopicRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}