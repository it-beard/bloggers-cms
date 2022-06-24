using Pds.Core.Enums;

namespace Pds.Web.Pages.Brands.Components;

public static class BrandsHelper
{
    public static string GetBgColorClass(bool isArchived)
    {
        return isArchived switch
        {
            false => "active",
            true => "archived"
        };
    }
}