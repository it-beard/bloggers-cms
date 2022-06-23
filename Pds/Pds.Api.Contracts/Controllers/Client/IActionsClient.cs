namespace Pds.Api.Contracts.Controllers.Client;

public interface IActionsClient
{
    Guid Id { get; set; }
        
    string Name { get; set; }
    
    int BillsCount { get; set; }
}