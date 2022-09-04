using Pds.Core.Enums;

namespace Pds.Web.Pages.Clients.Components;

public static class ClientsHelper
{
    public static string GetPaymentTypeBgColorClass(PaymentType? type)
    {
        return type == PaymentType.BankAccount ? "white" : "red";
    }
    
    public static string GetBgColorClass(ClientStatus clientStatus)
    {
        return clientStatus switch
        {
            ClientStatus.Active => "active",
            ClientStatus.Archived => "archived",
            _ => string.Empty
        };
    }
}