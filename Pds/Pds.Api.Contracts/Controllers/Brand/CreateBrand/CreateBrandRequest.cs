using System.ComponentModel.DataAnnotations;

namespace Pds.Api.Contracts.Controllers.Brand.CreateBrand;

public class CreateBrandRequest
{
    [Required]
    public string Name { get; set; }

    public string Info { get; set; }
}