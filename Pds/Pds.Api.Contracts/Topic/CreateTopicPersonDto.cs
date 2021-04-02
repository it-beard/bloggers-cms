using System;

namespace Pds.Api.Contracts.Topic
{
    public class CreateTopicPersonDto
    {
        public Guid PersonId { get; set; }

        public bool IsSelected { get; set; }
    }
}