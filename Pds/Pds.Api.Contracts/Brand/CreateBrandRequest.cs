using System.ComponentModel.DataAnnotations;

namespace Pds.Api.Contracts.Brand;

public class CreateBrandRequest
{
    [Required]
    public string Name { get; set; }

    public string Info { get; set; }
}