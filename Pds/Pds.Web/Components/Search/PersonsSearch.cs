using System.Linq.Expressions;
using Calabonga.PredicatesBuilder;
using Pds.Api.Contracts.Controllers.Person.GetPersons;

namespace Pds.Web.Components.Search;

public class PersonsSearch
{
    public Expression<Func<GetPersonsPersonDto, bool>> GetSearchPredicate(string searchLine)
    {
        var predicate = PredicateBuilder.False<GetPersonsPersonDto>();

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