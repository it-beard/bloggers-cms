namespace Pds.Api.Contracts.Paging
{
    public abstract class PageSettings
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}