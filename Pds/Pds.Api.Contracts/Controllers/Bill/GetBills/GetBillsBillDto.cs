using Pds.Core.Enums;

namespace Pds.Api.Contracts.Controllers.Bill.GetBills;

public class GetBillsBillDto : IActionsBill
{
    public Guid Id { get; set; }
        
    public decimal Value { get; set; }

    public DateTime PaidAt { get; set; }

    public BillType Type { get; set; }

    public PaymentStatus PaymentStatus { get; set; }

    public BillStatus Status { get; set; }

    public PaymentType PaymentType { get; set; }

    public string Comment { get; set; }

    public GetBillsContentDto Content { get; set; }

    public BrandDto Brand { get; set; }
    
    public GetBillsClientDto Client { get; set; }
        
    public bool IsVisible { get; set; }
}