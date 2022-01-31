using Pds.Api.Contracts.Content;
using Pds.Core.Enums;

namespace Pds.Web.Pages.Content;

public static class ContentHelper
{
    public static string GetContentBgColorClass(ContentStatus contentStatus, IPaymentStatus bill)
    {
        if (bill == null)
        {
            switch (contentStatus)
            {
                case ContentStatus.Active:
                    return "free";
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