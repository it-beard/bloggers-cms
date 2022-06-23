using Pds.Core.Enums;

namespace Pds.Web.Pages.Clients.Components;

public static class ClientsHelper
{
    public static string GetPaymentTypeBgColorClass(PaymentType? type)
    {
        return type == PaymentType.BankAccount ? "white" : "red";
    }
}