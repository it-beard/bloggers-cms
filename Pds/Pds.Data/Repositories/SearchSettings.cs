using System;

namespace Pds.Data.Repositories
{
    public class SearchSettings<T> where T : Enum
    {
        public PageSettings PageSettings { get; set; }
        public OrderSetting<T>[] OrderSettings { get; set; }
        public FilterSettings FilterSettings { get; set; }
    }
}