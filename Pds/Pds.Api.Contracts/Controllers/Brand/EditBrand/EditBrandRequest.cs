using System.ComponentModel.DataAnnotations;

namespace Pds.Api.Contracts.Controllers.Brand.EditBrand;

public class EditBrandRequest
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Info { get; set; }
}