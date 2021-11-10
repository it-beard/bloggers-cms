namespace Pds.Web.Components.Sorting.QueryCreators;

public interface IOrderQuery<out TOut, TIn>
{
    IOrderedQueryable<TOut> CreateOrderBy(IQueryable<TIn> query, bool ascending);
    IOrderedQueryable<TOut> CreateThenBy(IOrderedQueryable<TIn> query, bool ascending);
}