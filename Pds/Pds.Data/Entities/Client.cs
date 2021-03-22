using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pds.Data.Enums;

namespace Pds.Data.Entities
{
    public class Client : EntityBase
    {
        [Required]
        [Column(TypeName = "varchar(300)")]
        public string Name { get; set; }

        public string Comment { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}