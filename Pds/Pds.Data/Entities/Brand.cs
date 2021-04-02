using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pds.Data.Entities
{
    public class Brand : EntityBase
    {
        [Required]
        [Column(TypeName = "varchar(300)")]
        public string Name { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(300)")]
        public string Url { get; set; }

        public ICollection<Bill> Bills { get; set; }

        public ICollection<Content> Contents { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}