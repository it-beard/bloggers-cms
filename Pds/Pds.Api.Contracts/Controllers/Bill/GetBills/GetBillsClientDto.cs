namespace Pds.Api.Contracts.Controllers.Bill.GetBills;

public class GetBillsClientDto
{
    public Guid Id { get; set; }
        
    public string Name { get; set; }
        
    public string Comment { get; set; }
    
    public int BillsCount { get; set; }
}