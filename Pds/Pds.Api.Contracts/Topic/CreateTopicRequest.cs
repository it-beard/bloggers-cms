using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Pds.Api.Contracts.Person;
using Pds.Core.Attributes;

namespace Pds.Api.Contracts.Topic
{
    public class CreateTopicRequest
    {
        [Required, StringLength(300, MinimumLength = 3)]
        public string Name { get; set; }

        public ICollection<Guid> People { get; set; }
    }

    public class UpdateTopicRequest
    {
        [Required, StringLength(300, MinimumLength = 3)]
        public string Name { get; set; }

        public ICollection<Guid> People { get; set; }
    }
}