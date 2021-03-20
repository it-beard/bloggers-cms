using Pds.Api.Contracts.Paging;

namespace Pds.Api.Contracts.Person
{
    public class GetPersonsRequest : SearchSettings<PersonsFieldName>
    {
    }
    
    public enum PersonsFieldName
    {
        FullName,
        Rating,
        Location
    }
}