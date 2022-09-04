using Pds.Core.Enums;

namespace Pds.Web.Pages.Costs.Components;

public static class CostsHelper
{
    public static string GetBgColorClass(CostStatus status)
    {
        return status switch
        {
            CostStatus.Active => "active",
            CostStatus.Archived => "archived",
            _ => string.Empty
        };
    }
}