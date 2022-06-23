using Pds.Core.Enums;

namespace Pds.Web.Pages.Persons.Components;

public static class PersonsHelper
{
    public static string GetBgColorClass(PersonStatus personStatus)
    {
        return personStatus switch
        {
            PersonStatus.Active => "active",
            PersonStatus.Archived => "archived",
            _ => string.Empty
        };
    }
}