using Calabonga.PredicatesBuilder;
using System;
using System.Linq.Expressions;
using Pds.Api.Contracts.Topic;

namespace Pds.Web.Components.Search.Person
{
    public class TopicsSearch
    {
        public Expression<Func<TopicDto, bool>> GetSearchPredicate(string searchLine)
        {
            var predicate = PredicateBuilder.False<TopicDto>();
            predicate = predicate.Or(c => c.Name.ToLower().Contains(searchLine));

            return predicate;
        }
    }
}
