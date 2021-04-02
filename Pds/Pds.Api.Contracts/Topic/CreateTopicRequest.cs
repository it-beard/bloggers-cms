using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Pds.Api.Contracts.Person;

namespace Pds.Api.Contracts.Topic
{
    public class CreateTopicRequest
    {
        [Required, StringLength(300, MinimumLength = 3)]
        public string Name { get; set; }

        public ICollection<CreateTopicPersonDto> People { get; set; }
    }
}