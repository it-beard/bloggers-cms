using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pds.Core.Enums;

namespace Pds.Data.Entities;

public class Cost : EntityBase
{
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Value { get; set; }

    public string Comment { get; set; }
        
    public DateTime PaidAt { get; set; }
        
    public CostType Type { get; set; }

    [Required]
    public CostStatus Status { get; set; }

    public Guid BrandId { get; set; }
        
    public virtual Brand Brand { get; set; }

    public Guid? ContentId { get; set; }

    public virtual Content Content { get; set; }
}