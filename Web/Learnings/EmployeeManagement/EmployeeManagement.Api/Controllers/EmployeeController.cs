using EmployeeManagement.Api.Repository;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
	[Route("/api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		#region Fields
		private readonly IEmployeeRepository employeeRepository;
		#endregion

		#region Constructors
		public EmployeeController(IEmployeeRepository employeeRepository)
		{
			this.employeeRepository = employeeRepository;
		}
		#endregion

		#region Publics
		[HttpGet]
		public async Task<ActionResult> GetEmployees()
		{
			try
			{
				return Ok(await employeeRepository.GetEmployees());
			}
			catch(Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
			}
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<Employee>> GetEmployeeById(int id)
		{
			try
			{
				var result = await employeeRepository.GetEmployeeById(id);
				if(result == null) return NotFound();

				return result;
			}
			catch(Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
			}
		}

		[HttpPost]
		public async Task<ActionResult<Employee>> AddEmployee([FromBody]Employee? employee)
		{
			try
			{
				if(employee == null) return BadRequest();
				var createdEmployee = await employeeRepository.AddEmployee(employee);

				return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.EmployeeId }, createdEmployee);
			}
			catch(Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new employee record");
			}
		}

		[HttpPut("{id:int}")]
		public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee? employee)
		{
			try
			{
				if(id != employee?.EmployeeId) return BadRequest("Employee ID Mismatch.");

				var employeeToUpdate = await employeeRepository.GetEmployeeById(id);
				if(employeeToUpdate == null) return NotFound($"Employee with Id = {id} Not Found.");

				return await employeeRepository.UpdateEmployee(employee) ?? throw new Exception();
			}
			catch(Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data.");
			}
		}

		[HttpDelete("{id:int}")]
		public async Task<ActionResult<Employee>> DeleteEmployee(int id)
		{
			try
			{
				var employeeToDelete = await employeeRepository.GetEmployeeById(id);
				if(employeeToDelete == null) return NotFound($"Employee with Id = {id} Not Found.");

				return await employeeRepository.DeleteEmployee(id) ?? throw new Exception();
			}
			catch(Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data.");
			}
		}

		[HttpGet("{search}")]
		public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployees(string name, Gender? gender)
		{
			try
			{
				var result = await employeeRepository.SearchEmployees(name, gender);
				if(result.Any()) return Ok(result);

				return NotFound();
			}
			catch(Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
			}
		}
		#endregion
	}
}