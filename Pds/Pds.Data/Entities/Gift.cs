using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pds.Core.Enums;

namespace Pds.Data.Entities;

public class Gift : EntityBase
{
    [Required]
    public string Title { get; set; }

    public string Comment { get; set; }

    [Required]
    public GiftStatus Status { get; set; }
    
    public GiftStatus? PreviousStatus { get; set; }
        
    [Required]
    public GiftType Type { get; set; }
    
    [Column(TypeName = "varchar(300)")]
    public string FirstName { get; set; }
    
    [Column(TypeName = "varchar(300)")]
    public string LastName { get; set; }

    [Column(TypeName = "varchar(300)")]
    public string ThirdName { get; set; }
    
    public string PostalAddress { get; set; }

    public DateTime? RaffledAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public Guid BrandId { get; set; }

    public Guid? ContentId { get; set; }
        
    public virtual Brand Brand { get; set; }

    public virtual Content Content { get; set; }
}