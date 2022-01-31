namespace Pds.Services.Models.Dashboard;

public class ContentStatisticsBrandModel
{
    public string BrandName { get; set; }
    
    public Guid BrandId { get; set; }
    
    public List<ContentStatisticsContentModel> Contents { get; set; }
}