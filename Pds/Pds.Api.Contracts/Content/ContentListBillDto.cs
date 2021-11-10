using Pds.Core.Enums;

namespace Pds.Api.Contracts.Content;

public class ContentListBillDto : IPaymentStatus
{
    public decimal Value { get; set; }
        
    public PaymentStatus PaymentStatus { get; set; }

    public PaymentType? PaymentType { get; set; }
}