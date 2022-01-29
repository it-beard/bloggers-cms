using Pds.Api.Contracts.Brand;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Content.GetContent;

public class GetContentResponse
{
    public Guid Id { get; set; }
    
    public Guid BrandId { get; set; }
    public string Title { get; set; }
        
    public ContentType Type { get; set; }
        
    public ContentStatus Status { get; set; }
        
    public SocialMediaType SocialMediaType { get; set; }

    public string Comment { get; set; }
        
    public DateTime ReleaseDate { get; set; }

    public DateTime? EndDate { get; set; }

    public GetContentBillDto Bill { get; set; }

    public BrandDto Brand { get; set; }

    public GetContentPersonDto Person { get; set; }

    public List<GetContentCostDto> Costs { get; set; }
}