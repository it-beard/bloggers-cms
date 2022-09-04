using System.ComponentModel.DataAnnotations;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Controllers.Client.CreateClient;

public class CreateClientRequest
{
    [Required]
    public string Name { get; set; }

    public string Country { get; set; }

    public string Comment { get; set; }
}