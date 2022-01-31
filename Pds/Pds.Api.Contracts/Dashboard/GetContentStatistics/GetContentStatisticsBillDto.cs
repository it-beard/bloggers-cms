using Pds.Api.Contracts.Content;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Dashboard.GetContentStatistics;

public class GetContentStatisticsBillDto : IPaymentStatus
{
    public PaymentStatus PaymentStatus { get; set; }
}