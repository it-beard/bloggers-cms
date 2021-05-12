using System.Linq;
using Pds.Api.Contracts.Topic;

namespace Pds.Web.Components.Sorting.QueryCreators.Topic
{
    public class TopicStatusOrderQueryCreator : IOrderQuery<GetTopicDto, GetTopicDto>
    {
        public IOrderedQueryable<GetTopicDto> CreateOrderBy(IQueryable<GetTopicDto> query, bool ascending)
        {
            return ascending ? query.OrderBy(topic => topic.Status) : query.OrderByDescending(topic => topic.Status);
        }


        public IOrderedQueryable<GetTopicDto> CreateThenBy(IOrderedQueryable<GetTopicDto> query, bool ascending)
        {
            return ascending ? query.ThenBy(topic => topic.Status) : query.ThenByDescending(topic => topic.Status);
        }
    }
}