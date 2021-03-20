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
    }
}