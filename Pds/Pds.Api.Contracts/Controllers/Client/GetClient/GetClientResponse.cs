namespace Pds.Api.Contracts.Controllers.Client.GetClient;

public class GetClientResponse : IActionsClient
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Comment { get; set; }

    public string Country { get; set; }
    
    public int BillsCount { get; set; }
        
    public List<GetClientBillDto> Bills { get; set; }
}