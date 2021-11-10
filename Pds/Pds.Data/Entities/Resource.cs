using System.ComponentModel.DataAnnotations;

namespace Pds.Data.Entities;

public class Resource : EntityBase
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Url { get; set; }

    public Guid PersonId { get; set;  }

    public virtual Person Person { get; set;  }
}