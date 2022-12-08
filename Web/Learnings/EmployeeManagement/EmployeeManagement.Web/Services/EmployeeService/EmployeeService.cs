using EmployeeManagement.Models;

namespace EmployeeManagement.Web.Services
{
	public class EmployeeService : IEmployeeService
	{
		#region Fields
		private readonly HttpClient httpClient;
		#endregion

		#region Constructors
		public EmployeeService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}
		#endregion

		#region Publics
		public async Task<IEnumerable<Employee>?> GetEmployees()
		{
			return await httpClient.GetFromJsonAsync<Employee[]>("api/Employee");
		}

		public async Task<Employee?> GetEmployeeById(int id)
		{
			return await httpClient.GetFromJsonAsync<Employee>($"api/Employee/{id}");
		}
		#endregion
	}
}