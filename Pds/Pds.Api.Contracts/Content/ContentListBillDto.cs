using System;
using System.ComponentModel.DataAnnotations;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Content
{
    public class ContentListBillDto
    {
        public decimal Cost { get; set; }
        
        public BillStatus Status { get; set; }

        public PaymentType? PaymentType { get; set; }
    }
}