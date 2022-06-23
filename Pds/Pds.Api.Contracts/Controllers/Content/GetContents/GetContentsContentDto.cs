using Pds.Core.Enums;

namespace Pds.Api.Contracts.Controllers.Content.GetContents;

public class GetContentsContentDto : IActionsContent
{
    public Guid Id { get; set; }
        
    public string Title { get; set; }
        
    public ContentStatus Status { get; set; }
        
    public string ClientName { get; set; }
        
    public DateTime ReleaseDate { get; set; }

    public DateTime? EndDate { get; set; }
        
    public SocialMediaType SocialMediaType { get; set; }

    public ContentType Type { get; set; }

    public GetContentsBillDto Bill { get; set; }
    
    public PaymentStatus? BillPaymentStatus { get; set; }
    
    public GetContentsPersonDto Person { get; set; }

    public BrandDto Brand { get; set; }
}