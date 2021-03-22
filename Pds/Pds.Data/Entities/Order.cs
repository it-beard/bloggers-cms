using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pds.Core.Enums;

namespace Pds.Data.Entities
{
    public class Order : EntityBase
    {
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }
        
        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        [Column(TypeName = "varchar(300)")]
        public string PrimaryContact { get; set; }

        public Guid ContentId { get; set; }

        public Guid ClientId { get; set; }

        public virtual Content Content { get; set; }

        public virtual Client Client { get; set; }
    }
}