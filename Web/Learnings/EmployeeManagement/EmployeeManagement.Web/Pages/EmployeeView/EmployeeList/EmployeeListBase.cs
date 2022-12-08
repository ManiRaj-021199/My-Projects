using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
	public class EmployeeListBase : ComponentBase
	{
		#region Properties
		[Inject]
		public IEmployeeService? EmployeeService { get; set; }

		public IEnumerable<Employee>? Employees { get; set; }
		#endregion

		#region Protecteds
		protected override async Task OnInitializedAsync()
		{
			this.Employees = (await this.EmployeeService?.GetEmployees()! ?? Array.Empty<Employee>()).ToList();
		}
		#endregion
	}
}