using System.Linq.Expressions;
using Calabonga.PredicatesBuilder;
using Pds.Api.Contracts.Controllers.Content.GetContents;

namespace Pds.Web.Components.Search;

public class ContentsSearch
{
    public Expression<Func<GetContentsContentDto, bool>> GetSearchPredicate(string searchLine)
    {
        searchLine = searchLine.ToLower();
        var predicate = PredicateBuilder.False<GetContentsContentDto>();

        predicate = predicate.Or(c => c.Title.ToLower().Contains(searchLine));
        predicate = predicate.Or(c => c.ClientName != null 
                                      && c.ClientName.ToLower().Contains(searchLine));
        predicate = predicate.Or(c => c.EndDate != null 
                                      && !string.IsNullOrWhiteSpace(c.EndDate.Value.ToString("dd.MM.yyyy")) 
                                      && c.EndDate.Value.ToString("dd.MM.yyyy").ToLower().Contains(searchLine));
        predicate = predicate.Or(c => !string.IsNullOrWhiteSpace(c.ReleaseDate.ToString("dd.MM.yyyy")) 
                                      && c.ReleaseDate.ToString("dd.MM.yyyy").ToLower().Contains(searchLine));

        predicate = predicate.Or(r => r.Brand != null 
                                      && r.Brand.Name != null
                                      && r.Brand.Name.ToLower().Contains(searchLine));
        predicate = predicate.Or(r => r.Person != null 
                                      && r.Person.FirstName != null 
                                      && r.Person.FirstName.ToLower().Contains(searchLine));
        predicate = predicate.Or(r => r.Person != null 
                                      && r.Person.LastName != null
                                      && r.Person.LastName.ToLower().Contains(searchLine));
        predicate = predicate.Or(r => r.Person != null 
                                      && r.Person.ThirdName != null 
                                      && r.Person.ThirdName.ToLower().Contains(searchLine));
        predicate = predicate.Or(r => r.Bill != null 
                                      && r.Bill.Contact != null
                                      && r.Bill.Contact.ToLower().Contains(searchLine));
        predicate = predicate.Or(r => r.Bill != null 
                                      && r.Bill.ContactName != null
                                      && r.Bill.ContactName.ToLower().Contains(searchLine));
        predicate = predicate.Or(r => r.Bill != null && r.Bill.Value.ToString("N0").Contains(searchLine));

        return predicate;
    }
}