using System.Linq.Expressions;
using Calabonga.PredicatesBuilder;
using Pds.Api.Contracts.Controllers.Client.GetClients;
using Pds.Core.Extensions;

namespace Pds.Web.Components.Search;

public class ClientsSearch
{
    public Expression<Func<GetClientsClientDto, bool>> GetSearchPredicate(string searchLine)
    {
        searchLine = searchLine.ToLower();
        var predicate = PredicateBuilder.False<GetClientsClientDto>();

        predicate = predicate.Or(c => c.Id.ToShortString().Contains(searchLine));
        predicate = predicate.Or(c => c.Name != null 
                                      && c.Name.ToLower().Contains(searchLine));
        predicate = predicate.Or(c => c.Comment != null 
                                      && c.Comment.ToLower().Contains(searchLine));
        predicate = predicate.Or(c => c.Country != null 
                                      && c.Country.ToLower().Contains(searchLine));
        return predicate;
    }
}