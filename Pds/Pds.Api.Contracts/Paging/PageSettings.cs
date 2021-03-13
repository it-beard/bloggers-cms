namespace Pds.Api.Contracts.Paging
{
    public class PageSettings
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
    }

    public class OrderSetting
    {
        public bool Ascending { get; set; }
        public FieldName FieldName { get; set; }
    }

    public enum FieldName
    {
        FullName,
        Rating,
        Location
    }

    public class FilterSettings
    {
        public string Search { get; set; }
    }

    public abstract class SearchSettings
    {
        public PageSettings PageSettings { get; set; }
        public OrderSetting[] OrderSettings { get; set; }
        public FilterSettings FilterSettings { get; set; }
    }
}