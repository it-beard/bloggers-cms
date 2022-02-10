using Pds.Core.Enums;

namespace Pds.Api.Contracts.Content.GetContent;

public class GetContentBillDto : IPaymentStatus
{
    public Guid Id { get; set; }

    public decimal Value { get; set; }

    public string Comment { get; set; }

    public string Contact { get; set; }
    
    public string ContactEmail { get; set; }
        
    public string ContactName { get; set; }

    public ContactType? ContactType { get; set; }

    public PaymentStatus PaymentStatus { get; set; }

    public PaymentType? PaymentType { get; set; }

    public DateTime? PaidAt { get; set; }

    public string ContractNumber { get; set; }

    public DateTime? ContractDate { get; set; }

    public bool IsNeedPayNds { get; set; }

    public Guid ClientId { get; set; }
        
    public GetContentBillClientDto Client { get; set; }
}