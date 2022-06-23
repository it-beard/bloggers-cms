namespace Pds.Api.Contracts.Controllers.Dashboard.GetContentStatistics;

public class GetContentStatisticsBrandDto
{
    public string BrandName { get; set; }
    
    public Guid BrandId { get; set; }
    
    public List<GetContentStatisticsContentDto> Contents { get; set; }
}