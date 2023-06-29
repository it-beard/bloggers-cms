using Pds.Api.Contracts.Controllers.Person.GetPersons;

namespace Pds.Web.Components.Sorting.QueryCreators.Person;

public partial class PersonRateOrderQueryCreator : IOrderQuery<GetPersonsPersonDto, GetPersonsPersonDto>
{
    public IOrderedQueryable<GetPersonsPersonDto> CreateOrderBy(IQueryable<GetPersonsPersonDto> query, bool ascending)
    {
        if (ascending)
        {
            return query.OrderBy(x => x.Rate);
        }
        else
        {
            return query.OrderByDescending(x => x.Rate);
        }
    }

    public IOrderedQueryable<GetPersonsPersonDto> CreateThenBy(IOrderedQueryable<GetPersonsPersonDto> query, bool ascending)
    {
        if (ascending)
        {
            return query.ThenBy(x => x.Rate);
        }
        else
        {
            return query.ThenByDescending(x => x.Rate);
        }
    }
}