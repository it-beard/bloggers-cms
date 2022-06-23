using Pds.Core.Enums;

namespace Pds.Api.Contracts.Controllers.Cost;

public interface IActionsCost
{
    Guid Id { get; set; }

    CostStatus Status { get; set; }
}