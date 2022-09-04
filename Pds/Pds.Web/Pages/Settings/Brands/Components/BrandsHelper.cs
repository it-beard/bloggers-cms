namespace Pds.Web.Pages.Settings.Brands.Components;

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