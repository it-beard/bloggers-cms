using System.Linq;
using Pds.Api.Contracts.Person;

namespace Pds.Web.Components.Sorting.QueryCreators.Person
{
    public class PersonFullNameOrderQueryCreator : IOrderQuery<PersonDto>
    {
        public IOrderedQueryable<PersonDto> CreateOrderBy(IQueryable<PersonDto> query, bool ascending)
        {
            if (ascending)
            {
                return query.OrderBy(p => p.FullName);
            }
            else
            {
                return query.OrderByDescending(p => p.FullName);
            }

        }

        public IOrderedQueryable<PersonDto> CreateThenBy(IOrderedQueryable<PersonDto> query, bool ascending)
        {
            if (ascending)
            {
                return query.ThenBy(p => p.FullName);
            }
            else
            {
                return query.ThenByDescending(p => p.FullName);
            }
        }
    }
}
