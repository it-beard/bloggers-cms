using Pds.Core.Enums;

namespace Pds.Api.Contracts.Controllers.Content;

public interface IPaymentStatus
{
    PaymentStatus PaymentStatus { get; set; }
}