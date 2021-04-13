using System;

namespace Pds.Api.Contracts.Paging
{
    public class PageSettings
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
    }

    public class OrderSetting<T> where T : Enum
    {
        public bool Ascending { get; set; }
        public T FieldName { get; set; }
    }

    public class FilterSettings
    {
        public string Search { get; set; }
    }

    public abstract class SearchSettings<T> where T : Enum
    {
        public PageSettings PageSettings { get; set; }
        public OrderSetting<T>[] OrderSettings { get; set; }
        public FilterSettings FilterSettings { get; set; }
    }
}