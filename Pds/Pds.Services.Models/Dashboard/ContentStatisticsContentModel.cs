using Pds.Core.Enums;

namespace Pds.Services.Models.Dashboard;

public class ContentStatisticsContentModel
{
    public string Title { get; set; }
    
    public Guid Id { get; set; }
    
    public DateTime ReleaseDate { get; set; }
    
    public SocialMediaType SocialMediaType { get; set; }
    
    public PaymentStatus? BillPaymentStatus { get; set; }
}