namespace Pds.Web.Components.Pagination;

public struct PagingEventArgs
{
    public int PageSize { get; }
    public int PageOffSet { get; }

    public PagingEventArgs(int pageSize, int pageOffSet)
    {
        PageSize = pageSize;
        PageOffSet = pageOffSet;
    }
}