using Pds.Core.Enums;

namespace Pds.Api.Contracts.Cost;

public class GetCostResponse
{
    public Guid Id { get; set; }
        
    public decimal Value { get; set; }

    public string Comment { get; set; }
        
    public DateTime PaidAt { get; set; }
        
    public CostType Type { get; set; }
        
    public Guid BrandId { get; set; }

    public Guid? ContentId { get; set; }
}