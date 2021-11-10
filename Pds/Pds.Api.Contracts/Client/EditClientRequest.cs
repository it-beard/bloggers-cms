using System.ComponentModel.DataAnnotations;

namespace Pds.Api.Contracts.Client;

public class EditClientRequest
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Comment { get; set; }
}