using Pds.Api.Contracts.Person;
using System.Linq;

namespace Pds.Web.Components.Sorting.QueryCreators
{
    public interface IOrderQuery<out T>
    {
        IOrderedQueryable<T> CreateOrderBy(IQueryable<PersonDto> query, bool ascending);
        IOrderedQueryable<T> CreateThenBy(IOrderedQueryable<PersonDto> query, bool ascending);
    }
}
