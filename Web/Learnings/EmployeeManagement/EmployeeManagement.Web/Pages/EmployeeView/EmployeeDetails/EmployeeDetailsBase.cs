using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        #region Properties
        public Employee? Employee { get; set; } = new();

        [Inject]
        public IEmployeeService? EmployeeService { get; set; }

        [Parameter]
        public string? Id { get; set; }

        protected string? ToggleFooterButtonText { get; set; } = "Hide Footer";
        protected string? ToggleFooterCssClass { get; set; } = string.Empty;
        #endregion

        #region Protecteds
        protected override async Task OnInitializedAsync()
        {
            this.Id ??= "1";
            this.Employee = await this.EmployeeService!.GetEmployeeById(int.Parse(this.Id));
        }

        protected void ToggleFooter()
        {
            if(this.ToggleFooterButtonText == "Hide Footer")
            {
                this.ToggleFooterButtonText = "Show Footer";
                this.ToggleFooterCssClass = "hideFooter";
            }
            else
            {
                this.ToggleFooterButtonText = "Hide Footer";
                this.ToggleFooterCssClass = string.Empty;
            }
        }
        #endregion
    }
}