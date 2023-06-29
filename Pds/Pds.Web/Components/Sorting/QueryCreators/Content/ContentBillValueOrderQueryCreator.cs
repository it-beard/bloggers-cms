using Pds.Api.Contracts.Controllers.Content.GetContents;

namespace Pds.Web.Components.Sorting.QueryCreators.Content;

public partial class ContentBillValueOrderQueryCreator : IOrderQuery<GetContentsContentDto, GetContentsContentDto>
{
    public IOrderedQueryable<GetContentsContentDto> CreateOrderBy(IQueryable<GetContentsContentDto> query, bool ascending)
    {
        if (ascending)
        {
            return query.OrderBy(x => GetBillValue(x.Bill));
        }
        else
        {
            return query.OrderByDescending(x => GetBillValue(x.Bill));
        }
    }

    public IOrderedQueryable<GetContentsContentDto> CreateThenBy(IOrderedQueryable<GetContentsContentDto> query, bool ascending)
    {
        if (ascending)
        {
            return query.ThenBy(x => GetBillValue(x.Bill));
        }
        else
        {
            return query.ThenByDescending(x => GetBillValue(x.Bill));
        }
    }

    private decimal GetBillValue(GetContentsBillDto bill)
    {
        return bill?.Value ?? 0;
    }
}