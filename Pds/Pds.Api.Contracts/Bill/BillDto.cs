using Pds.Api.Contracts.Brand;
using Pds.Api.Contracts.Client;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Bill;

public class BillDto
{
    public Guid Id { get; set; }
        
    public decimal Value { get; set; }

    public DateTime PaidAt { get; set; }

    public BillType Type { get; set; }

    public PaymentStatus PaymentStatus { get; set; }

    public BillStatus Status { get; set; }

    public PaymentType PaymentType { get; set; }

    public string Comment { get; set; }

    public BillContentDto Content { get; set; }

    public BrandDto Brand { get; set; }
    
    public ClientDto Client { get; set; }
        
    public bool IsVisible { get; set; }
}