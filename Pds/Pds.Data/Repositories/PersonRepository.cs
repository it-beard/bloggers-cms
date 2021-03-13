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

        public async Task<Person[]> GetAllWithResourcesAsync(SearchSettings searchSettings)
        {
            var query = context.Persons
                .AsNoTracking()
                .Include(p => p.Resources)
                .AsQueryable();

            if (searchSettings.OrderSettings?.Length > 0)
            {
                var orderSettings = searchSettings.OrderSettings;

                IOrderedQueryable<Person> orderedQuery = null;

                if (orderSettings[0].Ascending)
                {
                    switch (orderSettings[0].FieldName)
                    {
                        case FieldName.FullName:
                            orderedQuery = query
                                .OrderBy(p => p.LastName + p.FirstName + p.ThirdName);
                            break;

                        case FieldName.Rating:
                            orderedQuery = query
                                .OrderBy(p => p.Rate);
                            break;

                        case FieldName.Location:
                            orderedQuery = query
                                .OrderBy(p => p.Country + p.City);
                            break;
                    }
                }
                else
                {
                    switch (orderSettings[0].FieldName)
                    {
                        case FieldName.FullName:
                            orderedQuery = query
                                .OrderByDescending(p => p.LastName + p.FirstName + p.ThirdName);
                            break;

                        case FieldName.Rating:
                            orderedQuery = query
                                .OrderByDescending(p => p.Rate);
                            break;

                        case FieldName.Location:
                            orderedQuery = query
                                 .OrderByDescending(p => p.Country + p.City);
                            break;
                    }
                }

                foreach (var orderSetting in orderSettings.Skip(1))
                {
                    if (orderSetting.Ascending)
                    {
                        switch (orderSetting.FieldName)
                        {
                            case FieldName.FullName:
                                orderedQuery = orderedQuery
                                    .ThenBy(p => p.LastName + p.FirstName + p.ThirdName);
                                break;

                            case FieldName.Rating:
                                orderedQuery = orderedQuery
                                    .ThenBy(p => p.Rate);
                                break;

                            case FieldName.Location:
                                orderedQuery = orderedQuery
                                    .ThenBy(p => p.Country + p.City);
                                break;
                        }
                    }
                    else
                    {
                        switch (orderSetting.FieldName)
                        {
                            case FieldName.FullName:
                                orderedQuery = orderedQuery
                                    .ThenByDescending(p => p.LastName + p.FirstName + p.ThirdName);
                                break;

                            case FieldName.Rating:
                                orderedQuery = orderedQuery
                                    .ThenByDescending(p => p.Rate);
                                break;

                            case FieldName.Location:
                                orderedQuery = orderedQuery
                                     .ThenByDescending(p => p.Country + p.City);
                                break;
                        }
                    }
                }

                query = orderedQuery;
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
        
        public async Task<List<Person>> GetForListsAsync()
        {
            return await context.Persons
                .Where(p => p.Status == PersonStatus.Active)
                .OrderBy(p =>p.FirstName)
                .ThenBy(p=>p.LastName)
                .ToListAsync();
        }
    }

    public class PageSettings
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
    }

    public class OrderSetting
    {
        public bool Ascending { get; set; }
        public FieldName FieldName { get; set; }
    }

    public enum FieldName
    {
        FullName,
        Rating,
        Location
    }

    public class FilterSettings
    {
        public string Search { get; set; }
    }

    public class SearchSettings
    {
        public PageSettings PageSettings { get; set; }
        public OrderSetting[] OrderSettings { get; set; }
        public FilterSettings FilterSettings { get; set; }
    }
}