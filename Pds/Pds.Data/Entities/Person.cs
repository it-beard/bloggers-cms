using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pds.Data.Enums;

namespace Pds.Data.Entities
{
    public class Person : EntityBase
    {
        [Required]
        [Column(TypeName = "varchar(300)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "varchar(300)")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(300)")]
        public string ThirdName { get; set; }

        public string Info { get; set; }

        public int? Rate { get; set; }

        public PersonStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? ArchivedAt { get; set; }

        public DateTime? UnarchivedAt { get; set; }

        public ICollection<Resource> Resources { get; set; }
    }
}