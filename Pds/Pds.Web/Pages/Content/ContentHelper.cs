using Pds.Api.Contracts.Content;
using Pds.Core.Enums;

namespace Pds.Web.Pages.Content
{
    public static class ContentHelper
    {
        public static string GetContentBgColorClass(ContentStatus contentStatus, IBillStatus bill)
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
                ContentStatus.Active when bill.Status == BillStatus.Active => "active-not-paid",
                ContentStatus.Active when bill.Status == BillStatus.Paid => "active-paid",
                ContentStatus.Archived when bill.Status == BillStatus.Paid => "archived-paid",
                ContentStatus.Archived when bill.Status == BillStatus.Active => "archived-not-paid",
                _ => string.Empty
            };
        }
    
        public static string GetPaymentTypeBgColorClass(PaymentType? type)
        {
            return type == PaymentType.BankAccount ? "white" : "red";
        }
    }
}