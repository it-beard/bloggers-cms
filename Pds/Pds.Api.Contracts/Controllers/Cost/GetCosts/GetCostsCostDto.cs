using Pds.Core.Enums;

namespace Pds.Api.Contracts.Controllers.Cost.GetCosts;

public class GetCostsCostDto : IActionsCost
{
    public Guid Id { get; set; }

    public decimal Value { get; set; }

    public DateTime PaidAt { get; set; }

    public CostType Type { get; set; }

    public CostStatus Status { get; set; }

    public string Comment { get; set; }

    public GetCostContentDto Content { get; set; }

    public BrandDto Brand { get; set; }
}