using Pds.Api.Contracts.Content;
using Pds.Core.Enums;

namespace Pds.Web.Pages.Content
{
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
}