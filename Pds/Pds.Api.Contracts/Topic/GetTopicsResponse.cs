using System.Collections.Generic;
using System.Linq;

namespace Pds.Api.Contracts.Topic
{
    public class GetTopicsResponse
    {
        public GetTopicsResponse()
        {
        }

        public GetTopicsResponse(IEnumerable<GetTopicDto> items, int total)
        {
            Items = items as IReadOnlyList<GetTopicDto> ?? items.ToList();
            Total = total;
        }
        
        public IReadOnlyList<GetTopicDto> Items { get; set; }

        public long Total { get; set; }
    }
}