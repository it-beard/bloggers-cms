namespace Pds.Api.Contracts.Paging;

public class PageResult<T>
{
    public List<T> Items { get; set; }
    public int Total { get; set; }
}