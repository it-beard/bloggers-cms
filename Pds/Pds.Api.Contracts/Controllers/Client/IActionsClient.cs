using Pds.Core.Enums;

namespace Pds.Api.Contracts.Controllers.Client;

public interface IActionsClient
{
    Guid Id { get; set; }
        
    string Name { get; set; }
    
    ClientStatus Status { get; set; }
    
    int BillsCount { get; set; }
}