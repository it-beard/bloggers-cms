namespace Pds.Web.Models.Gift;

public class FilterSettings
{
    public List<BrandFilterItem> BrandFilterItems { get; set; }

    public List<GiftTypeFilterItem> GiftTypeFilterItems { get; set; }

    public List<GiftStatusFilterItem> GiftStatusFilterItems { get; set; }
    
    public DateTime? CreatedFrom { get; set; }

    public DateTime? CreatedTo { get; set; }
    
    public DateTime? RaffledFrom { get; set; }

    public DateTime? RaffledTo { get; set; }
    
    public DateTime? CompletedFrom { get; set; }

    public DateTime? CompletedTo { get; set; }
}