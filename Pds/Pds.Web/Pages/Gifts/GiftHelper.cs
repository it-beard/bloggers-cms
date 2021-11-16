using Pds.Api.Contracts.Content;
using Pds.Core.Enums;

namespace Pds.Web.Pages.Gifts;

public static class GiftHelper
{
    public static string GetGiftBgColorClass(GiftStatus giftStatus)
    {
        return giftStatus switch
        {
            GiftStatus.New => "status-new",
            GiftStatus.Raffled => "status-raffled",
            GiftStatus.Waiting => "status-waiting",
            GiftStatus.Strange => "status-strange",
            GiftStatus.Completed => "status-completed",
            _ => string.Empty
        };
    }
}