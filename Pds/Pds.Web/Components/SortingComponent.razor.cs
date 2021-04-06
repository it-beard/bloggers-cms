using Microsoft.AspNetCore.Components;
using Pds.Api.Contracts.Person;

namespace Pds.Web.Components
{
    public class SortingComponentModel : ComponentBase
    {
        [Parameter]
        public EventCallback<SortingEventArgs> OnSortPersons { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public PersonsFieldName FieldName { get; set; }

        protected bool ascending;

        protected void OnSortColumn()
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

        public PersonsFieldName FieldName { get; }
        public bool Ascending { get; }
    }
}
