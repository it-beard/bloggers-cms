using System.Linq;
using Pds.Data.Entities;

namespace Pds.Data.QueryCreators
{
    public class PersonFullNameOrderQueryCreator : IOrderQuery<Person>
    {
        public IOrderedQueryable<Person> CreateOrderBy(IQueryable<Person> query, bool ascending)
        {
            if (ascending)
            {
                return query.OrderBy(p => p.LastName + p.FirstName + p.ThirdName);
            }
            else
            {
                return query.OrderByDescending(p => p.LastName + p.FirstName + p.ThirdName);
            }
        }

        public IOrderedQueryable<Person> CreateThenBy(IOrderedQueryable<Person> query, bool ascending)
        {
            if (ascending)
            {
                return query.ThenBy(p => p.LastName + p.FirstName + p.ThirdName);
            }
            else
            {
                return query.ThenByDescending(p => p.LastName + p.FirstName + p.ThirdName);
            }
        }
    }
}