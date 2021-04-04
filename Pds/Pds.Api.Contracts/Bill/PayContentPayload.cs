using System;
using System.ComponentModel.DataAnnotations;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Bill
{
    public class PayBillPayload
    {
        [Required]
        public PaymentType PaymentType { get; set; }

        [Required]
        [Range(10.00, Double.MaxValue, ErrorMessage = "Значение поля {0} должно быть больше чем {1}.")]
        public decimal Value { get; set; }

        public string Comment { get; set; }

        public DateTime PaidAt { get; set; }
    }
}