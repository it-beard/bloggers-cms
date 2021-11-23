using Calabonga.PredicatesBuilder;
using Pds.Api.Contracts.Gift;
using System.Linq.Expressions;

namespace Pds.Web.Components.Search.Gift;

public class GiftsSearch
{
    public Expression<Func<GiftDto, bool>> GetSearchPredicate(string searchLine)
    {
        searchLine = searchLine.ToLower();
        var predicate = PredicateBuilder.False<GiftDto>();

        predicate = predicate.Or(c => c.Title.ToLower().Contains(searchLine));
        predicate = predicate.Or(c => !string.IsNullOrWhiteSpace(c.FirstName) && c.FirstName.ToLower().Contains(searchLine));
        predicate = predicate.Or(c => !string.IsNullOrWhiteSpace(c.LastName) && c.LastName.ToLower().Contains(searchLine));
        predicate = predicate.Or(c => !string.IsNullOrWhiteSpace(c.ThirdName) && c.ThirdName.ToLower().Contains(searchLine));
        predicate = predicate.Or(c => !string.IsNullOrWhiteSpace(c.PostalAddress) && c.PostalAddress.ToLower().Contains(searchLine));
        predicate = predicate.Or(c => !string.IsNullOrWhiteSpace(c.Comment) && c.Comment.ToLower().Contains(searchLine));
        predicate = predicate.Or(c => 
            c.CompletedAt != null &&
            !string.IsNullOrWhiteSpace(c.CompletedAt.Value.ToString("dd.MM.yyyy")) && 
            c.CompletedAt.Value.ToString("dd.MM.yyyy").ToLower().Contains(searchLine));
        predicate = predicate.Or(c => 
            c.CompletedAt != null &&
            !string.IsNullOrWhiteSpace(c.CompletedAt.Value.ToString("dd.MM.yyyy")) && 
            c.CompletedAt.Value.ToString("dd.MM.yyyy").ToLower().Contains(searchLine));
        predicate = predicate.Or(c => 
            c.RaffledAt != null &&
            !string.IsNullOrWhiteSpace(c.RaffledAt.Value.ToString("dd.MM.yyyy")) && 
            c.RaffledAt.Value.ToString("dd.MM.yyyy").ToLower().Contains(searchLine));
        predicate = predicate.Or(c => 
            !string.IsNullOrWhiteSpace(c.CreatedAt.ToString("dd.MM.yyyy")) && 
            c.CreatedAt.ToString("dd.MM.yyyy").ToLower().Contains(searchLine));

        predicate = predicate.Or(r => r.Content != null && r.Content.Title.ToLower().Contains(searchLine));

        return predicate;
    }
}