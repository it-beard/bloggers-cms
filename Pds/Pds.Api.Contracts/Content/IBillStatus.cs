using Pds.Core.Enums;

namespace Pds.Api.Contracts.Content
{
    public interface IBillStatus
    {
        BillStatus Status { get; set; }
    }
}