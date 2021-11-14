using Pds.Core.Enums;

namespace Pds.Web.Models.Gift;

public class GiftStatusFilterItem
{
    public GiftStatus GiftStatus { get; set; }

    public bool IsSelected { get; set; }
}