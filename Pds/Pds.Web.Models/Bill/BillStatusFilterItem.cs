using Pds.Core.Enums;

namespace Pds.Web.Models.Bill;

public class BillStatusFilterItem
{
    public BillStatus BillStatus { get; set; }

    public bool IsSelected { get; set; }
}