using Microsoft.AspNetCore.Components;
using Pds.Api.Contracts.Person;

namespace Pds.Web.Components
{
    public partial class SortingComponent
    {
        [Parameter]
        public EventCallback<SortingEventArgs> OnSortPersons { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public PersonsFieldName FieldName { get; set; }

        private bool ascending;

        private void OnSortColumn()
        {
            ascending = !ascending;

            OnSortPersons.InvokeAsync(new SortingEventArgs(FieldName, ascending));
        }
    }

    public struct SortingEventArgs
    {
        public SortingEventArgs(PersonsFieldName personsFieldName, bool ascending)
        {
            FieldName = personsFieldName;
            Ascending = ascending;
        }

        public PersonsFieldName FieldName { get; set; }
        public bool Ascending { get; set; }
    }
}
