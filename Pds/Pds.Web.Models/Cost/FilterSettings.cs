using System;
using System.Collections.Generic;

namespace Pds.Web.Models.Cost
{
    public class FilterSettings
    {
        public List<CostTypeFilterItem> CostTypeFilterItems { get; set; }
        public List<BrandFilterItem> BrandFilterItems { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }
    }
}