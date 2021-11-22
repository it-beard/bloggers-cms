namespace Pds.Api.Contracts.Paging;

public class PageSettings
{
    public int Limit { get; set; }
    public int Offset { get; set; }
}

public class OrderSetting<T> where T : Enum
{
    public bool Ascending { get; set; } = true;
    public T FieldName { get; set; }
}