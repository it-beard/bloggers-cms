using System.Linq;
using Pds.Api.Contracts.Topic;

namespace Pds.Web.Components.Sorting.QueryCreators.Topic
{
    public class TopicNameOrderQueryCreator : IOrderQuery<TopicDto, TopicDto>
    {
        public IOrderedQueryable<TopicDto> CreateOrderBy(IQueryable<TopicDto> query, bool @ascending) =>
            ascending ? query.OrderBy(topic => topic.Name) : query.OrderByDescending(topic => topic.Name);
            

        public IOrderedQueryable<TopicDto> CreateThenBy(IOrderedQueryable<TopicDto> query, bool @ascending) =>
            ascending ? query.ThenBy(topic => topic.Name) : query.ThenByDescending(topic => topic.Name);

    }
}