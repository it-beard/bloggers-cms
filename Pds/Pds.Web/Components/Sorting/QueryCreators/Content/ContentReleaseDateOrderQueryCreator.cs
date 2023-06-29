using Pds.Api.Contracts.Controllers.Content.GetContents;

namespace Pds.Web.Components.Sorting.QueryCreators.Content;

public partial class ContentReleaseDateOrderQueryCreator : IOrderQuery<GetContentsContentDto, GetContentsContentDto>
{
    public IOrderedQueryable<GetContentsContentDto> CreateOrderBy(IQueryable<GetContentsContentDto> query, bool ascending)
    {
        if (ascending)
        {
            return query.OrderBy(x => x.ReleaseDate);
        }
        else
        {
            return query.OrderByDescending(x => x.ReleaseDate);
        }
    }

    public IOrderedQueryable<GetContentsContentDto> CreateThenBy(IOrderedQueryable<GetContentsContentDto> query, bool ascending)
    {
        if (ascending)
        {
            return query.ThenBy(x => x.ReleaseDate);
        }
        else
        {
            return query.ThenByDescending(x => x.ReleaseDate);
        }
    }
}