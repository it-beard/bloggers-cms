using System.Collections.Generic;
using Pds.Api.Contracts.Person;

namespace Pds.Api.Contracts.Topic
{
    public class GetTopicDto
    {
        public string Name { get; set; }

        public IReadOnlyList<PersonDto> People { get; set; }
    }
}