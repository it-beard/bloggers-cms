using Pds.Api.Contracts.Controllers.Person.GetPersons;

namespace Pds.Web.Components.Sorting.QueryCreators.Person;

public class PersonFullNameOrderQueryCreator : IOrderQuery<GetPersonsPersonDto, GetPersonsPersonDto>
{
    public IOrderedQueryable<GetPersonsPersonDto> CreateOrderBy(IQueryable<GetPersonsPersonDto> query, bool ascending)
    {
        if (ascending)
        {
            return query.OrderBy(p => p.FullName);
        }
        else
        {
            return query.OrderByDescending(p => p.FullName);
        }

    }

    public IOrderedQueryable<GetPersonsPersonDto> CreateThenBy(IOrderedQueryable<GetPersonsPersonDto> query, bool ascending)
    {
        if (ascending)
        {
            return query.ThenBy(p => p.FullName);
        }
        else
        {
            return query.ThenByDescending(p => p.FullName);
        }
    }
}