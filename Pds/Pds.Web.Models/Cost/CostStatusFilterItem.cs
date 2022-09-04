using Pds.Core.Enums;

namespace Pds.Web.Models.Cost;

public class CostStatusFilterItem
{
    public CostStatus CostStatus { get; set; }

    public bool IsSelected { get; set; }
}