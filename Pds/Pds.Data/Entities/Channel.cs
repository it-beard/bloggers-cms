using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pds.Data.Enums;

namespace Pds.Data.Entities
{
    public class Channel : EntityBase
    {
        [Required]
        [Column(TypeName = "varchar(300)")]
        public string Name { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(300)")]
        public string Url { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}