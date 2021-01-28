using System;
using System.ComponentModel.DataAnnotations;

namespace Pds.Data.Entities
{
    public class Resource : EntityBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Person Person { get; set;  }
    }
}