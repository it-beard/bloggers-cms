using Pds.Core.Enums;

namespace Pds.Api.Contracts.Controllers.Gift;

public interface IActionsGift
{
    Guid Id { get; set; }

    GiftStatus Status { get; set; }
}