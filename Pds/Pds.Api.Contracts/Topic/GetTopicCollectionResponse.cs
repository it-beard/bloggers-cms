using System.Collections.Generic;
using System.Linq;

namespace Pds.Api.Contracts.Topic
{
    public class GetTopicCollectionResponse
    {
        public GetTopicCollectionResponse()
        {
        }

        public GetTopicCollectionResponse(IEnumerable<GetTopicDto> items)
        {
            Items = items as IReadOnlyList<GetTopicDto> ?? items.ToList();
        }
        
        public IReadOnlyList<GetTopicDto> Items { get; set; }
    }
}