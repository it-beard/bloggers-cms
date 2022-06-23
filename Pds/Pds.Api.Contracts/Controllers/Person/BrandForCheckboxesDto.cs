namespace Pds.Api.Contracts.Controllers.Person;

public class BrandForCheckboxesDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public bool IsSelected { get; set; }
    
    public bool IsDefault { get; set; }
}