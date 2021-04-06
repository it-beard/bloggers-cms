using System.Linq;
using Pds.Data.Entities;

namespace Pds.Data.QueryCreators
{
    public class PersonLocationOrderQueryCreator : IOrderQuery<Person>
    {
        public IOrderedQueryable<Person> CreateOrderBy(IQueryable<Person> query, bool ascending)
        {
            if (ascending)
            {
                return query.OrderBy(x => x.City + x.Country);
            }
            else
            {
                return query.OrderByDescending(x => x.City + x.Country);
            }
        }

        public IOrderedQueryable<Person> CreateThenBy(IOrderedQueryable<Person> query, bool ascending)
        {
            if (ascending)
            {
                return query.ThenBy(x => x.City + x.Country);
            }
            else
            {
                return query.ThenByDescending(x => x.City + x.Country);
            }
        }
    }
}