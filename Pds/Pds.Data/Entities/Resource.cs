using System;

namespace Pds.Data.Entities
{
    public class Resource : EntityBase
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Person Person { get; set;  }
    }
}