using Pds.Core.Enums;

namespace Pds.Web.Models.Cost;

public class CostTypeFilterItem
{
    public CostType CostType { get; set; }

    public bool IsSelected { get; set; }
}