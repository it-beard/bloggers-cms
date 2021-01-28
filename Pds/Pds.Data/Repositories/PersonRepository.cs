using Pds.Data.Entities;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        private readonly ApplicationDbContext context;
        
        public PersonRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        // Can bee extended by any additional methods that do not present in RepositoryBase
    }
}