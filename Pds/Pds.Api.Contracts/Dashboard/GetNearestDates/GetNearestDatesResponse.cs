namespace Pds.Api.Contracts.Dashboard.GetNearestDates;

public class GetNearestDatesResponse
{
    public DateTime? NearestDateForIntegration { get; set; }
    
    public DateTime? NearestDateForNewEpisode { get; set; }
    
    public string ContentTitleForIntegration { get; set; }
    
    public Guid ContentIdForIntegration { get; set; }
}