using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Pds.Data.Entities
{
    public class Topic : EntityBase
    {
        public Topic()
        {
            
        }

        [Required]
        [Column(TypeName = "varchar(300)")]
        public string Name { get; set; }
        
        public virtual ICollection<PersonTopic> PersonTopics { get; set; }

    }
}
