using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pds.Core.Enums;

namespace Pds.Data.Entities
{
    public class Bill : EntityBase
    {
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }
        
        [Required]
        public BillStatus Status { get; set; }
        
        [Required]
        public BillType Type { get; set; }

        public PaymentType? PaymentType { get; set; }

        public string Comment { get; set; }

        [Required]
        [Column(TypeName = "varchar(300)")]
        public string Contact { get; set; }

        [Column(TypeName = "varchar(300)")]
        public string ContactName { get; set; }

        [Required]
        public ContactType ContactType { get; set; }

        public DateTime? PaidAt { get; set; }

        public Guid BrandId { get; set; }

        public Guid? ContentId { get; set; }

        public Guid? ClientId { get; set; }
        
        public virtual Brand Brand { get; set; }

        public virtual Content Content { get; set; }

        public virtual Client Client { get; set; }
    }
}