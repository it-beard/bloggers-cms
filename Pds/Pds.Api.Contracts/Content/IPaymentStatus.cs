using Pds.Core.Enums;

namespace Pds.Api.Contracts.Content
{
    public interface IPaymentStatus
    {
        PaymentStatus PaymentStatus { get; set; }
    }
}