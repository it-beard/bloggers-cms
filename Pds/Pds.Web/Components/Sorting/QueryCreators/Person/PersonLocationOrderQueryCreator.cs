using System.Linq;
using Pds.Api.Contracts.Person;

namespace Pds.Web.Components.Sorting.QueryCreators.Person
{
    public class PersonLocationOrderQueryCreator : IOrderQuery<PersonDto, PersonDto>
    {
        public IOrderedQueryable<PersonDto> CreateOrderBy(IQueryable<PersonDto> query, bool ascending)
        {
            if (ascending)
            {
                return query.OrderBy(x => x.Location);
            }
            else
            {
                return query.OrderByDescending(x => x.Location);
            }
        }

        public IOrderedQueryable<PersonDto> CreateThenBy(IOrderedQueryable<PersonDto> query, bool ascending)
        {
            if (ascending)
            {
                return query.ThenBy(x => x.Location);
            }
            else
            {
                return query.ThenByDescending(x => x.Location);
            }
        }
    }
}