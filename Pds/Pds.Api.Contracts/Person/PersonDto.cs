using Pds.Core.Enums;

namespace Pds.Api.Contracts.Person;

public class PersonDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string ThirdName { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
        
    public string FullName { get; set; }

    public string Country { get; set; }

    public string City { get; set; }
        
    public string Location { get; set; }
        
    public string Topics { get; set; }
        
    public string Info { get; set; }
        
    public int? Rate { get; set; }

    public PersonStatus Status { get; set; }
        
    public List<ResourceDto> Resources { get; set; }
        
    public List<PersonContentDto> Contents { get; set; }

    public List<BrandDto> Brands { get; set; }
}