using Calabonga.PredicatesBuilder;
using System.Linq.Expressions;
using Pds.Api.Contracts.Bill;
using Pds.Core.Extensions;

namespace Pds.Web.Components.Search.Bills;

public class BillsSearch
{
    public Expression<Func<BillDto, bool>> GetSearchPredicate(string searchLine)
    {
        searchLine = searchLine.ToLower();
        var predicate = PredicateBuilder.False<BillDto>();

        predicate = predicate.Or(c => c.Id.ToShortString().Contains(searchLine));
        predicate = predicate.Or(c => c.Value.ToString("N0").Contains(searchLine));
        predicate = predicate.Or(c => c.Comment != null 
                                      && c.Comment.ToLower().Contains(searchLine));
        predicate = predicate.Or(c => !string.IsNullOrWhiteSpace(c.PaidAt.ToString("dd.MM.yyyy")) 
                                      && c.PaidAt.ToString("dd.MM.yyyy").ToLower().Contains(searchLine));

        predicate = predicate.Or(r => r.Brand != null 
                                      && r.Brand.Name != null
                                      && r.Brand.Name.ToLower().Contains(searchLine));
        predicate = predicate.Or(r => r.Content != null
                                      && r.Content.Title != null
                                      && r.Content.Title.ToLower().Contains(searchLine));
        predicate = predicate.Or(r => r.Client != null
                                      && r.Client.Name != null
                                      && r.Client.Name.ToLower().Contains(searchLine));
        return predicate;
    }
}