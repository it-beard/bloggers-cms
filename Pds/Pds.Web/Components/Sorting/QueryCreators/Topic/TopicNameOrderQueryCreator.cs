using System.Linq;
using Pds.Api.Contracts.Topic;

namespace Pds.Web.Components.Sorting.QueryCreators.Topic
{
    public class TopicNameOrderQueryCreator : IOrderQuery<GetTopicDto, GetTopicDto>
    {
        public IOrderedQueryable<GetTopicDto> CreateOrderBy(IQueryable<GetTopicDto> query, bool @ascending) =>
            ascending ? query.OrderBy(topic => topic.Name) : query.OrderByDescending(topic => topic.Name);
            

        public IOrderedQueryable<GetTopicDto> CreateThenBy(IOrderedQueryable<GetTopicDto> query, bool @ascending) =>
            ascending ? query.ThenBy(topic => topic.Name) : query.ThenByDescending(topic => topic.Name);

    }
}