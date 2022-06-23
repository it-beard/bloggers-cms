using Pds.Core.Enums;

namespace Pds.Api.Contracts.Controllers.Client.GetClients;

public class GetClientsBillDto : IClientForBill
{
    public Guid Id { get; set; }

    public decimal Value { get; set; }

    public PaymentStatus PaymentStatus { get; set; }

    public BillType Type { get; set; }

    public PaymentType? PaymentType { get; set; }

    public string Comment { get; set; }

    public string Contact { get; set; }

    public string ContactName { get; set; }

    public ContactType? ContactType { get; set; }

    public string ContractNumber { get; set; }

    public DateTime? ContractDate { get; set; }

    public bool IsNeedPayNds { get; set; }

    public DateTime? PaidAt { get; set; }

    public Guid BrandId { get; set; }

    public Guid? ContentId { get; set; }

    public Guid? ClientId { get; set; }
}