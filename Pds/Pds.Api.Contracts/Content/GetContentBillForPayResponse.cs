using Pds.Core.Enums;

namespace Pds.Api.Contracts.Content;

public class GetContentBillForPayResponse
{
    public string Id { get; set; }

    public decimal Value { get; set; }

    public string Comment { get; set; }

    public PaymentStatus PaymentStatus { get; set; }

    public PaymentType? PaymentType { get; set; }

    public DateTime? PaidAt { get; set; }

    public string ContractNumber { get; set; }

    public DateTime? ContractDate { get; set; }

    public bool IsNeedPayNds { get; set; }
}