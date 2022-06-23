using System.ComponentModel.DataAnnotations;

namespace Pds.Api.Contracts.Controllers.Person.EditPerson;

public class EditPersonRequest
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public string ThirdName { get; set; }

    public string Country { get; set; }

    public string City { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public bool IsContactEstablished { get; set; }
        
    public string Topics { get; set; }

    public string Info { get; set; }

    public int? Rate { get; set; }

    public List<BrandForCheckboxesDto> Brands { get; set; }

    public List<ResourceDto> Resources { get; set; }
}