using Pds.Api.Contracts.Person;

namespace Pds.Web.Components.Sorting
{
    public struct SortingEventArgs
    {
        public SortingEventArgs(PersonsFieldName personsFieldName, bool ascending)
        {
            FieldName = personsFieldName;
            Ascending = ascending;
        }

        public PersonsFieldName FieldName { get; }
        public bool Ascending { get; }
    }
}
