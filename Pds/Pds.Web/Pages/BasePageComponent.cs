using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Pds.Web.Common;

namespace Pds.Web.Pages
{
    [Authorize]
    public class BasePageComponent: ComponentBase
    {
        [Inject]
        protected NavigationManager _navManager { get; set; }
        [Inject]
        protected PageHistoryState _pageState { get; set; }
        public BasePageComponent(NavigationManager navManager, PageHistoryState pageState)
        {
            _navManager = navManager;
            _pageState = pageState;
        }

        public BasePageComponent()
        {
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _pageState.AddPage(_navManager.Uri);
        }
    
        protected void GoBack()
        {
            _navManager.NavigateTo(_pageState.PreviousPage());
        }
    }
}