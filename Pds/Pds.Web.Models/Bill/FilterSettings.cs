namespace Pds.Web.Models.Bill;

public class FilterSettings
{
    public List<SocialMediaFilterItem> SocialMediaFilterItems { get; set; }
    public List<BillTypeFilterItem> BillTypeFilterItems { get; set; }
    public List<PaymentTypeFilterItem> PaymentTypeFilterItems { get; set; }
    public List<BrandFilterItem> BrandFilterItems { get; set; }
    
    public List<BillStatusFilterItem> BillStatusFilterItems { get; set; }

    public DateTime? From { get; set; }

    public DateTime? To { get; set; }
}