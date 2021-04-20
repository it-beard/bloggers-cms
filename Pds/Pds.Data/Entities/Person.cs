using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pds.Core.Enums;

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

        [Column(TypeName = "varchar(300)")] public string ThirdName { get; set; }

        public string Info { get; set; }

        public int? Rate { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public PersonStatus Status { get; set; }

        public DateTime? ArchivedAt { get; set; }

        public DateTime? UnarchivedAt { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }

        public virtual ICollection<Content> Contents { get; set; }

        public virtual ICollection<Brand> Brands { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
    }
}