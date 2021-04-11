using System;
using System.ComponentModel.DataAnnotations;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Bill
{
    public class CreateBillRequest
    {
        [Required]
        public Guid BrandId { get; set; }

        [Range(10, Double.MaxValue, ErrorMessage = "Значение поля {0} должно быть больше чем {1}.")]
        public decimal Value { get; set; }

        [Required, EnumDataType(typeof(BillType))]
        public BillType Type { get; set; }

        [Required]
        public PaymentType PaymentType { get; set; }

        [Required]
        public DateTime PaidAt { get; set; }

        public string Comment { get; set; }

        public string ContractNumber { get; set; }

        public DateTime? ContractDate { get; set; }

        public bool IsNeedPayNds { get; set; }

        public Guid? ClientId { get; set; }

        public string Contact { get; set; }

        public string ContactName { get; set; }

        public ContactType ContactType { get; set; }
    }
}