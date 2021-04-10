using System.Collections.Generic;

namespace Pds.Web.Models.Content
{
    public class FilterSettings
    {
        public List<SocialMediaFilterItem> SocialMediaFilterItems { get; set; }
        public List<ContentTypeFilterItem> ContentTypeFilterItems { get; set; }
        public List<BrandFilterItem> BrandFilterItems { get; set; }
    }
}