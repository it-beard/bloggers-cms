using System;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Content
{
    public class GetContentForPayResponse
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public Guid BillId { get; set; }

        public decimal BillValue { get; set; }

        public string BillComment { get; set; }

        public BillStatus BillStatus { get; set; }

        public PaymentType? BillPaymentType { get; set; }

        public DateTime? BillPaidAt { get; set; }
    }
}