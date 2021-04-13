using Pds.Api.Contracts.Person;
using System.Linq;

namespace Pds.Web.Components.Sorting.QueryCreators.Person
{
    public partial class PersonRatingOrderQueryCreator : IOrderQuery<PersonDto>
    {
        public IOrderedQueryable<PersonDto> CreateOrderBy(IQueryable<PersonDto> query, bool ascending)
        {
            if (ascending)
            {
                return query.OrderBy(x => x.Rate);
            }
            else
            {
                return query.OrderByDescending(x => x.Rate);
            }
        }

        public IOrderedQueryable<PersonDto> CreateThenBy(IOrderedQueryable<PersonDto> query, bool ascending)
        {
            if (ascending)
            {
                return query.ThenBy(x => x.Rate);
            }
            else
            {
                return query.ThenByDescending(x => x.Rate);
            }
        }
    }
}
