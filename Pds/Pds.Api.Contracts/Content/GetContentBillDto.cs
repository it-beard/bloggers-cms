using System;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Content
{
    public class GetContentBillDto : IBillStatus
    {
        public Guid Id { get; set; }

        public decimal Value { get; set; }

        public string Comment { get; set; }

        public string Contact { get; set; }
        
        public string ContactName { get; set; }

        public ContactType ContactType { get; set; }

        public BillStatus Status { get; set; }

        public PaymentType? PaymentType { get; set; }

        public DateTime? PaidAt { get; set; }

        public string ContractNumber { get; set; }

        public DateTime? ContractDate { get; set; }

        public bool IsNeedPayNds { get; set; }
        
        public GetContentBillClientDto Client { get; set; }
    }
}