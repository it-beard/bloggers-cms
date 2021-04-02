using System.Collections.Generic;
using System.Linq;
using Pds.Api.Contracts.Person;

namespace Pds.Api.Contracts.Topic
{
    public class GetTopicsResponse
    {
        public GetTopicsResponse(IEnumerable<GetTopicDto> items, int total)
        {
            Items = items as IReadOnlyList<GetTopicDto> ?? items.ToList();
            Total = total;
        }

        public IReadOnlyList<GetTopicDto> Items { get; set; }

        public long Total { get; set; }
    }

    public class GetTopicDto
    {
        public string Name { get; set; }

        public IReadOnlyList<PersonDto> People { get; set; }
    }
}