using Pds.Core.Enums;

namespace Pds.Services.Models.Client;

public class EditClientModel
{
    public Guid Id { get; set; }
        
    public string Name { get; set; }

    public string Comment { get; set; }

    public string Country { get; set; }
    
    public ClientStatus Status { get; set; }
}