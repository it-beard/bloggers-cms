using Calabonga.PredicatesBuilder;
using Pds.Api.Contracts.Gift;
using System.Linq.Expressions;

namespace Pds.Web.Components.Search.Gift;

public class GiftsSearch
{
    public Expression<Func<GiftDto, bool>> GetSearchPredicate(string searchLine)
    {
        var predicate = PredicateBuilder.False<GiftDto>();

        predicate = predicate.Or(c => c.Title.ToLower().Contains(searchLine));
        predicate = predicate.Or(c => c.FirstName.ToLower().Contains(searchLine));
        predicate = predicate.Or(c => c.LastName.ToLower().Contains(searchLine));
        predicate = predicate.Or(c => c.ThirdName.ToLower().Contains(searchLine));
        predicate = predicate.Or(c => c.PostalAddress.ToLower().Contains(searchLine));
        predicate = predicate.Or(c => !string.IsNullOrWhiteSpace(c.Comment) && c.Comment.ToLower().Contains(searchLine));

        predicate = predicate.Or(r => r.Content != null && r.Content.Title.Contains(searchLine));

        return predicate;
    }
}