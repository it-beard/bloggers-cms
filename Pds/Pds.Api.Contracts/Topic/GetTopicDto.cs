using System;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Topic
{
    public class GetTopicDto
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string Name { get; set; }

        public TopicStatus Status { get; set; }
    }
}