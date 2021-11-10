using Calabonga.PredicatesBuilder;
using Pds.Api.Contracts.Person;
using System.Linq.Expressions;

namespace Pds.Web.Components.Search.Person;

public class PersonsSearch
{
    public Expression<Func<PersonDto, bool>> GetSearchPredicate(string searchLine)
    {
        var predicate = PredicateBuilder.False<PersonDto>();

        predicate = predicate.Or(c => !string.IsNullOrWhiteSpace(c.Location) && c.Location.ToLower().Contains(searchLine));
        predicate = predicate.Or(c => c.FullName.ToLower().Contains(searchLine));
        predicate = predicate.Or(c => !string.IsNullOrWhiteSpace(c.Info) && c.Info.ToLower().Contains(searchLine));
        predicate = predicate.Or(c => !string.IsNullOrWhiteSpace(c.Topics) && c.Topics.ToLower().Contains(searchLine));
        predicate = predicate.Or(c => c.Rate.ToString().Contains(searchLine));

        predicate = predicate.Or(r => r.Resources.Exists(s => s.Name.Contains(searchLine)));
        predicate = predicate.Or(r => r.Resources.Exists(s => s.Url.Contains(searchLine)));

        return predicate;
    }
}