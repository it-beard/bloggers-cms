using Pds.Api.Contracts.Controllers.Content;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Controllers.Dashboard.GetContentStatistics;

public class GetContentStatisticsBillDto : IPaymentStatus
{
    public PaymentStatus PaymentStatus { get; set; }
}