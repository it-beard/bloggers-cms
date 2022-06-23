using System.ComponentModel.DataAnnotations;

namespace Pds.Api.Contracts.Controllers.Person;

public class ResourceDto
{
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; }

    [Required]
    public string Url { get; set; }
}