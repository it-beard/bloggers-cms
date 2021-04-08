using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pds.Core.Enums;
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
        
        public async Task<List<Person>> GetAllFullAsync()
        {
            return await context.Persons
                .Include(p=>p.Brands)
                .Include(p=>p.Resources)
                .Include(p=>p.Contents)
                .OrderBy(p =>p.LastName)
                .ThenByDescending(p=>p.Rate)
                .ToListAsync();
        }
        
        public async Task<Person> GetFullByIdAsync(Guid personId)
        {
            return await context.Persons
                .Include(p=>p.Brands)
                .Include(p=>p.Resources)
                .Include(p=>p.Contents)
                .FirstOrDefaultAsync(c => c.Id == personId);
        }
        
        public async Task<List<Person>> GetForListsAsync()
        {
            return await context.Persons
                .Where(p => p.Status == PersonStatus.Active)
                .OrderBy(p =>p.FirstName)
                .ThenBy(p=>p.LastName)
                .ToListAsync();
        }
    }
}