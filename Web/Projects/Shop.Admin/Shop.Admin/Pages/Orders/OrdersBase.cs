using Microsoft.AspNetCore.Components;

namespace Shop.Admin.Pages
{
    public class OrdersBase : ComponentBase
    {
        #region Properties
        [CascadingParameter]
        public EventCallback EventNotify { get; set; }
        #endregion

        #region Protecteds
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender) await this.EventNotify.InvokeAsync();
        }
        #endregion
    }
}
