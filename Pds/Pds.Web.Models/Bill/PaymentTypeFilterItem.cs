using Pds.Core.Enums;

namespace Pds.Web.Models.Bill
{
    public class PaymentTypeFilterItem
    {
        public PaymentType PaymentType { get; set; }

        public bool IsSelected { get; set; }
    }
}