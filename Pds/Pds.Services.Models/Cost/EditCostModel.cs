using Pds.Core.Enums;

namespace Pds.Services.Models.Cost;

public class EditCostModel
{
    public Guid Id { get; set; }

    public decimal Value { get; set; }

    public string Comment { get; set; }
        
    public DateTime PaidAt { get; set; }

    public CostType Type { get; set; }

    public Guid BrandId { get; set; }

    public Guid? ContentId { get; set; }
}