using Pds.Core.Enums;
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
        
        public TopicStatus Status { get; set; }

        public DateTime? ArchivedAt { get; set; }

        public DateTime? UnarchivedAt { get; set; }

        public virtual ICollection<PersonTopic> PersonTopics { get; set; }

        public bool IsArchived => Status == TopicStatus.Archived;

        public bool IsActive => Status == TopicStatus.Active;

        public void Archive()
        {
            Status = TopicStatus.Archived;
            ArchivedAt = DateTime.UtcNow;
        }

        public void Unarchive()
        {
            Status = TopicStatus.Active;
            UnarchivedAt = DateTime.Now;
        }
    }
}
