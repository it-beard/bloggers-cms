using Pds.Core.Enums;

namespace Pds.Api.Contracts.Controllers.Bill;

public interface IActionsBill
{
    Guid Id { get; set; }
    
    BillType Type { get; set; }
    
    BillStatus Status { get; set; }
}