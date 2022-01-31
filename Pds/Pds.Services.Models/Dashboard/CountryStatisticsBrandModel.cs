namespace Pds.Services.Models.Dashboard;

public class CountryStatisticsBrandModel
{
    public string BrandName { get; set; }
    
    public Guid BrandId { get; set; }
    
    public List<CountryStatisticsCountryModel> Countries { get; set; }
}