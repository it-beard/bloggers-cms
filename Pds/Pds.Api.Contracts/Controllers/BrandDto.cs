namespace Pds.Api.Contracts.Controllers;

public class BrandDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public bool IsDefault { get; set; }
}