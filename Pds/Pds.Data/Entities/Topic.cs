using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pds.Core.Enums;

namespace Pds.Data.Entities
{
    public class Topic : EntityBase
    {
        [Required]
        [Column(TypeName = "varchar(300)")]
        public string Name { get; set; }

        public TopicStatus Status { get; set; }

        public virtual ICollection<Person> People { get; set; }

        public bool IsArchived => Status == TopicStatus.Archived;

        public bool IsActive => Status == TopicStatus.Active;

        public void Archive()
        {
            Status = TopicStatus.Archived;
        }

        public void Unarchive()
        {
            Status = TopicStatus.Active;
        }
    }
}