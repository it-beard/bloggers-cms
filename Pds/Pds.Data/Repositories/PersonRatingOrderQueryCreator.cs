using System.Linq;
using Pds.Data.Entities;

namespace Pds.Data.Repositories
{
    public class PersonRatingOrderQueryCreator : IOrderQuery<Person>
    {
        public IOrderedQueryable<Person> CreateOrderBy(IQueryable<Person> query, bool ascending)
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

        public IOrderedQueryable<Person> CreateThenBy(IOrderedQueryable<Person> query, bool ascending)
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