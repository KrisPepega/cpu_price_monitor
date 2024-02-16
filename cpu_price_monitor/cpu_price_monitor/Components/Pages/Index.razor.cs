using Microsoft.AspNetCore.Components;

namespace cpu_price_monitor.Components.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        public NavigationManager? navigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            navigationManager.NavigateTo("/Cpus");
        }
    }
}
