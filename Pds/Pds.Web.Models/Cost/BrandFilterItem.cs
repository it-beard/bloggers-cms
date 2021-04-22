using System;

namespace Pds.Web.Models.Cost
{
    public class BrandFilterItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}