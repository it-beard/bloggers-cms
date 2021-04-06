using System;

namespace Pds.Data.QueryCreators.Settings
{
    public class OrderSetting<T> where T : Enum
    {
        public bool Ascending { get; set; }
        public T FieldName { get; set; }
    }
}