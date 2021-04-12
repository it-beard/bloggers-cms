using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pds.Core.Enums;
using Pds.Data.Entities;
using Pds.Data.QueryCreators;
using Pds.Data.QueryCreators.Settings;
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

        public async Task<Person[]> GetAllWithResourcesAsync(SearchSettings<PersonsFieldName> searchSettings)
        {
            var query = context.Persons
                .AsNoTracking()
                .Include(p => p.Resources)
                .AsQueryable();

            if (searchSettings.OrderSettings?.Length > 0)
            {
                var dictionary = new Dictionary<PersonsFieldName, IOrderQuery<Person>>
                {
                    {PersonsFieldName.FullName, new PersonFullNameOrderQueryCreator()},
                    {PersonsFieldName.Rating, new PersonRatingOrderQueryCreator()},
                    {PersonsFieldName.Location, new PersonLocationOrderQueryCreator()}
                };
                
                var queryCreator = new PersonOrderQueryCreator(dictionary);
                query = queryCreator.Create(searchSettings.OrderSettings, query);
            }
            else
            {
                query = query
                    .OrderByDescending(p => p.Rate)
                    .ThenBy(p => p.LastName);
            }

            return await query
                .Skip(searchSettings.PageSettings?.Offset ?? 0)
                .Take(searchSettings.PageSettings?.Limit ?? 10)
                .ToArrayAsync();
        }

        public async Task<List<Person>> GetAllFullAsync()
        {
            return await context.Persons
                .Include(p => p.Brands)
                .Include(p => p.Resources)
                .Include(p => p.Contents)
                .OrderBy(p => p.LastName)
                .ThenByDescending(p => p.Rate)
                .ToListAsync();
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