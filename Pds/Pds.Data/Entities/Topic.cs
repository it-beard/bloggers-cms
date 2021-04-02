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

        public Topic(string name)
        {
            Name = name;
        }

        public Topic(string name, IEnumerable<Person> people)
        {
            Name = name;
            // ReSharper disable once VirtualMemberCallInConstructor
            PersonTopics = people.Select(p => new PersonTopic(Id, p.Id)).ToList();
        }

        [Required]
        [Column(TypeName = "varchar(300)")]
        public string Name { get; set; }
        
        public virtual ICollection<PersonTopic> PersonTopics { get; set; }

    }
}
