using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pds.Data.Entities
{
    public class Client : EntityBase
    {
        [Required]
        [Column(TypeName = "varchar(300)")]
        public string Name { get; set; }

        public string Comment { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}