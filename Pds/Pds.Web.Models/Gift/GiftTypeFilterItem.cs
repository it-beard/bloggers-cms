using Pds.Core.Enums;

namespace Pds.Web.Models.Gift;

public class GiftTypeFilterItem
{
    public GiftType GiftType { get; set; }

    public bool IsSelected { get; set; }
}