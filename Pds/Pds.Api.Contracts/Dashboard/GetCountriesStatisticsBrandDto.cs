namespace Pds.Api.Contracts.Dashboard;

public class GetCountriesStatisticsBrandDto
{
    public string BrandName { get; set; }
    
    
    public Guid BrandId { get; set; }
    
    public List<GetCountriesStatisticsCountryDto> Countries { get; set; }
}