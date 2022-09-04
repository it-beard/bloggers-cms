using Pds.Core.Enums;

namespace Pds.Web.Pages.Bills.Components;

public static class BillsHelper
{
    public static string GetBgColorClass(BillStatus status)
    {
        return status switch
        {
            BillStatus.Active => "active",
            BillStatus.Archived => "archived",
            _ => string.Empty
        };
    }
}