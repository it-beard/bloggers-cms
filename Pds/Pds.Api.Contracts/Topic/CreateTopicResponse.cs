using System;

namespace Pds.Api.Contracts.Topic
{
    public class CreateTopicResponse
    {
        public CreateTopicResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}