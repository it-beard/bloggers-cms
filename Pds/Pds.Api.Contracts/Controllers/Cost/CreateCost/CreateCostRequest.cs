using System.ComponentModel.DataAnnotations;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Controllers.Cost.CreateCost;

public class CreateCostRequest
{
    [Required]
    [Range(10.00, Double.MaxValue, ErrorMessage = "Значение поля {0} должно быть больше чем {1}.")]
    public decimal Value { get; set; }

    public string Comment { get; set; }

    [Required]
    public DateTime PaidAt { get; set; }

    [Required, EnumDataType(typeof(CostType))]
    public CostType Type { get; set; }

    [Required]
    public Guid BrandId { get; set; }

    public Guid? ContentId { get; set; }
}