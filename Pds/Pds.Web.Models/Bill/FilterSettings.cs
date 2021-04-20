using System.Collections.Generic;

namespace Pds.Web.Models.Bill
{
    public class FilterSettings
    {
        public List<SocialMediaFilterItem> SocialMediaFilterItems { get; set; }

        public List<BillTypeFilterItem> BillTypeFilterItems { get; set; }
        public List<PaymentTypeFilterItem> PaymentTypeFilterItems { get; set; }
        public List<BrandFilterItem> BrandFilterItems { get; set; }
    }
}