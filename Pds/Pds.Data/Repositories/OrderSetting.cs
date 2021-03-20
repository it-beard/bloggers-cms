using System;

namespace Pds.Data.Repositories
{
    public class OrderSetting<T> where T : Enum
    {
        public bool Ascending { get; set; }
        public T FieldName { get; set; }
    }
}