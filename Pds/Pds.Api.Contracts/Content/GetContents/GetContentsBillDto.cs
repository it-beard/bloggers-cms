using Pds.Core.Enums;

namespace Pds.Api.Contracts.Content.GetContents;

public class GetContentsBillDto : IPaymentStatus
{
    public decimal Value { get; set; }
        
    public PaymentStatus PaymentStatus { get; set; }
    
    public string Contact { get; set; }
        
    public string ContactName { get; set; }

    public PaymentType? PaymentType { get; set; }
}