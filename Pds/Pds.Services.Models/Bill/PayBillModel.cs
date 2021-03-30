using System;
using Pds.Core.Enums;

namespace Pds.Services.Models.Bill
{
    public class PayBillModel
    {
        public Guid BillId { get; set; }

        public PaymentType PaymentType { get; set; }

        public decimal Cost { get; set; }

        public string Comment { get; set; }

        public DateTime PaidAt { get; set; }
    }
}