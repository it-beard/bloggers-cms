using System.Linq;
using Pds.Data.Entities;

namespace Pds.Data.QueryCreators
{
    public interface IOrderQuery<out T>
    {
        IOrderedQueryable<T> CreateOrderBy(IQueryable<Person> query, bool ascending);
        IOrderedQueryable<T> CreateThenBy(IOrderedQueryable<Person> query, bool ascending);
    }
}