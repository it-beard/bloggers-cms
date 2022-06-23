using System.ComponentModel.DataAnnotations;

namespace Pds.Api.Contracts.Controllers.Client.CreateClient;

public class CreateClientRequest
{
    [Required]
    public string Name { get; set; }

    public string Comment { get; set; }
}