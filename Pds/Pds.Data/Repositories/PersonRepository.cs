using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        
        public async Task<Person[]> GetAllWithResourcesAsync(int limit = 10, int offset = 0)
        {
            return await context.Persons
                .AsNoTracking()
                .Include(p=>p.Resources)
                .OrderByDescending(p =>p.Rate)
                .ThenBy(p=>p.LastName)
                .Skip(offset)
                .Take(limit)
                .ToArrayAsync();
        }
    }
}