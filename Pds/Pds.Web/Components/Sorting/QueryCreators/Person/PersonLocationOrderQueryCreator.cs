using Pds.Api.Contracts.Controllers.Person.GetPersons;

namespace Pds.Web.Components.Sorting.QueryCreators.Person;

public class PersonLocationOrderQueryCreator : IOrderQuery<GetPersonsPersonDto, GetPersonsPersonDto>
{
    public IOrderedQueryable<GetPersonsPersonDto> CreateOrderBy(IQueryable<GetPersonsPersonDto> query, bool ascending)
    {
        if (ascending)
        {
            return query.OrderBy(x => x.Location);
        }
        else
        {
            return query.OrderByDescending(x => x.Location);
        }
    }

    public IOrderedQueryable<GetPersonsPersonDto> CreateThenBy(IOrderedQueryable<GetPersonsPersonDto> query, bool ascending)
    {
        if (ascending)
        {
            return query.ThenBy(x => x.Location);
        }
        else
        {
            return query.ThenByDescending(x => x.Location);
        }
    }
}