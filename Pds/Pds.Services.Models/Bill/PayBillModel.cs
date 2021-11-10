using Pds.Core.Enums;

namespace Pds.Services.Models.Bill;

public class PayBillModel
{
    public Guid BillId { get; set; }

    public PaymentType PaymentType { get; set; }

    public decimal Value { get; set; }

    public string Comment { get; set; }

    public DateTime PaidAt { get; set; }

    public string ContractNumber { get; set; }

    public DateTime? ContractDate { get; set; }

    public bool IsNeedPayNds { get; set; }
}