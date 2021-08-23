using System.Linq;
using Pds.Api.Contracts.Topic;

namespace Pds.Web.Components.Sorting.QueryCreators.Topic
{
    public class TopicStatusOrderQueryCreator : IOrderQuery<TopicDto, TopicDto>
    {
        public IOrderedQueryable<TopicDto> CreateOrderBy(IQueryable<TopicDto> query, bool ascending)
        {
            return ascending ? query.OrderBy(topic => topic.Status) : query.OrderByDescending(topic => topic.Status);
        }


        public IOrderedQueryable<TopicDto> CreateThenBy(IOrderedQueryable<TopicDto> query, bool ascending)
        {
            return ascending ? query.ThenBy(topic => topic.Status) : query.ThenByDescending(topic => topic.Status);
        }
    }
}