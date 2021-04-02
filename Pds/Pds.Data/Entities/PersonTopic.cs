using System;
using System.Diagnostics;

namespace Pds.Data.Entities
{
    public class PersonTopic : IEquatable<PersonTopic>
    {
        public PersonTopic()
        {
            
        }

        public PersonTopic(Guid personId)
        {
            PersonId = personId;
        }

        public PersonTopic(Guid topicId, Guid personId)
        {
            TopicId = topicId;
            PersonId = personId;
        }
        
        public Guid PersonId { get; set; }

        public virtual Person Person { get; set; }

        public Guid TopicId { get; set; }

        public virtual Topic Topic { get; set; }
        
        public bool Equals(PersonTopic other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return PersonId.Equals(other.PersonId) && TopicId.Equals(other.TopicId);
        }
    }
}