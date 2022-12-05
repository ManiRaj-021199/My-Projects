using Microsoft.AspNetCore.Components;
using Shop.Admin.Services.AdminPanel;
using Shop.DataModels.CustomModels;

namespace Shop.Admin.Pages.Login
{
    public class LoginBase : ComponentBase
    {
        #region Properties
        public LoginModel? LoginModel { get; set; }
        public string AlertMessage { get; set; } = null!;

        [Inject]
        public IAdminPanelService? AdminPanelService { get; set; }

        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        #endregion

        #region Protecteds
        protected override Task OnInitializedAsync()
        {
            this.LoginModel = new LoginModel();

            return base.OnInitializedAsync();
        }

        protected async Task CheckLogin()
        {
            LoginResponseModel? response = await this.AdminPanelService!.AdminLogin(this.LoginModel);

            if(response!.Status)
            {
                this.NavigationManager?.NavigateTo("/");
            }
            else
            {
                this.AlertMessage = response.Message;
            }
        }
        #endregion
    }
}