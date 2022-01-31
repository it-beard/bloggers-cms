using Pds.Api.Contracts.Content;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Dashboard.GetContentStatistics;

public class GetContentStatisticsContentDto
{
    public string Title { get; set; }
    
    public Guid Id { get; set; }
    
    public DateTime ReleaseDate { get; set; }
    
    public ContentStatus Status { get; set; }
    
    public SocialMediaType SocialMediaType { get; set; }
    
    
    public GetContentStatisticsBillDto Bill { get; set; }
}