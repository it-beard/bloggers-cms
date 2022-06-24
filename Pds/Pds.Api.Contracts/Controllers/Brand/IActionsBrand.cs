namespace Pds.Api.Contracts.Controllers.Brand;

public interface IActionsBrand
{
    Guid Id { get; set; }
    
    string Name { get; set; }
    
    bool IsDefault { get; set; }
    
    bool IsDeletable { get; set; }
    
    bool IsArchived { get; set; }
}