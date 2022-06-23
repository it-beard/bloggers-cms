namespace Pds.Api.Contracts.Controllers.Dashboard.GetNearestDates;

public class GetNearestDatesResponse
{
    public string BrandName { get; set; }
    
    public DateTime? NearestDateForIntegration { get; set; }
    
    public DateTime? NearestDateForNewEpisode { get; set; }
    
    public string ContentTitleForIntegration { get; set; }
    
    public Guid ContentIdForIntegration { get; set; }
}