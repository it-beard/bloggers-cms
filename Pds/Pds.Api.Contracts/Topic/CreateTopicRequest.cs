using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pds.Api.Contracts.Topic
{
    public class CreateTopicRequest
    {
        [Required, StringLength(300, MinimumLength = 3)]
        public string Name { get; set; }

        public ICollection<Guid> People { get; set; }
    }
}