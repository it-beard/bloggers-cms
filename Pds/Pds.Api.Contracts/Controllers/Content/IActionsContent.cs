using Pds.Core.Enums;

namespace Pds.Api.Contracts.Controllers.Content;

public interface IActionsContent
{    
    Guid Id { get; set; }
        
    string Title { get; set; }
    
    ContentStatus Status { get; set; }
    
    PaymentStatus? BillPaymentStatus { get; set; }
}