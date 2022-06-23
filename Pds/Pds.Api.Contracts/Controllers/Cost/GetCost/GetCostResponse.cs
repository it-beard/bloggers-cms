using Pds.Core.Enums;

namespace Pds.Api.Contracts.Controllers.Cost.GetCost;

public class GetCostResponse : IActionsCost
{
    public Guid Id { get; set; }
        
    public decimal Value { get; set; }

    public string Comment { get; set; }
    public CostStatus Status { get; set; }
        
    public DateTime PaidAt { get; set; }
        
    public CostType Type { get; set; }
        
    public Guid BrandId { get; set; }

    public Guid? ContentId { get; set; }
}