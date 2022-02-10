using Pds.Core.Enums;

namespace Pds.Api.Contracts.Bill;

public class GetBillResponse
{
    public Guid Id { get; set; }
        
    public decimal Value { get; set; }

    public string Comment { get; set; }        

    public string ContractNumber { get; set; }

    public DateTime? ContractDate { get; set; }

    public bool IsNeedPayNds { get; set; }
        
    public DateTime PaidAt { get; set; }
        
    public BillType Type { get; set; }
        
    public PaymentType PaymentType { get; set; }
        
    public Guid BrandId { get; set; }

    public Guid? ClientId { get; set; }

    public string Contact { get; set; }

    public string ContactName { get; set; }
    
    public string ContactEmail { get; set; }

    public ContactType ContactType { get; set; }

    public BillContentDto Content { get; set; }
}