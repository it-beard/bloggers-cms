using Pds.Api.Contracts.Controllers.Content;
using Pds.Core.Enums;

namespace Pds.Web.Pages.Content.Components;

public static class ContentHelper
{
    public static string GetContentBgColorClass(ContentStatus contentStatus, IPaymentStatus bill, bool isFilmed)
    {
        if (bill == null)
        {
            switch (contentStatus)
            {
                case ContentStatus.Active:
                    return isFilmed ? "free" : "not-filmed";
                case ContentStatus.Archived:
                    return "archived-free";
            }
        }

        return contentStatus switch
        {
            ContentStatus.Active when bill.PaymentStatus == PaymentStatus.NotPaid =>
                "active-not-paid",
            ContentStatus.Active when bill.PaymentStatus == PaymentStatus.Paid =>
                "active-paid",
            ContentStatus.Archived when bill.PaymentStatus == PaymentStatus.Paid =>
                "archived-paid",
            ContentStatus.Archived when bill.PaymentStatus == PaymentStatus.NotPaid =>
                "archived-not-paid",
            _ => string.Empty
        };
    }

    public static string GetPaymentTypeBgColorClass(PaymentType? type)
    {
        return type == PaymentType.BankAccount ? "white" : "red";
    }
}