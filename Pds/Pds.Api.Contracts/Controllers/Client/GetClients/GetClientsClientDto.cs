using Pds.Core.Enums;

namespace Pds.Api.Contracts.Controllers.Client.GetClients;

public class GetClientsClientDto : IActionsClient
{
    public Guid Id { get; set; }
        
    public string Name { get; set; }
        
    public string Comment { get; set; }
        
    public string Country { get; set; }
    
    public ClientStatus Status { get; set; }
    
    public int BillsCount { get; set; }
        
    public List<GetClientsBillDto> Bills { get; set; }
}