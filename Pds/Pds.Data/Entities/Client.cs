using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pds.Core.Enums;

namespace Pds.Data.Entities;

public class Client : EntityBase
{
    [Required]
    [Column(TypeName = "varchar(300)")]
    public string Name { get; set; }
    
    [Column(TypeName = "varchar(30)")]
    public string Country { get; set; }

    public string Comment { get; set; } 
    
    public ClientStatus Status { get; set; }

    public virtual ICollection<Bill> Bills { get; set; }
}