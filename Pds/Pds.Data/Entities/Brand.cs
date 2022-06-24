using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pds.Data.Entities;

public class Brand : EntityBase
{
    [Required]
    [Column(TypeName = "varchar(300)")]
    public string Name { get; set; }
    
    [Column(TypeName = "varchar(300)")]
    public string Info { get; set; }
    
    public bool IsDefault { get; set; }
    
    public bool IsArchived { get; set; }

    public ICollection<Bill> Bills { get; set; }

    public ICollection<Cost> Costs { get; set; }

    public ICollection<Content> Contents { get; set; }

    public ICollection<Person> Persons { get; set; }

    public ICollection<Gift> Gifts { get; set; }
}