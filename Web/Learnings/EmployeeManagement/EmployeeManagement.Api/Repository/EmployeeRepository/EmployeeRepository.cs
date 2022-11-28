using EmployeeManagement.Api.Models;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;

        #region Constructors
        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        #endregion

        #region Publics
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await appDbContext.Employees.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeById(int nEmployeeId)
        {
            return await appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == nEmployeeId);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await appDbContext.Employees.AddAsync(employee);
            await appDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Employee?> DeleteEmployee(int nEmployeeId)
        {
            var result = GetEmployeeById(nEmployeeId).Result;
            if(result == null) return result;

            appDbContext.Employees.Remove(result);
            await appDbContext.SaveChangesAsync();

            return result;
        }

        public async Task<Employee?> UpdateEmployee(Employee employee)
        {
            var result = GetEmployeeById(employee.EmployeeId).Result;
            if(result == null) return result;
            
            result.FirstName = employee.FirstName;
            result.LastName = employee.LastName;
            result.Email = employee.Email;
            result.DateOfBirth = employee.DateOfBirth;
            result.Gender = employee.Gender;
            result.DepartmentId = employee.DepartmentId;
            result.PhotoPath = employee.PhotoPath;

            await appDbContext.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<Employee>> SearchEmployees(string name, Gender? gender)
        {
	        IQueryable<Employee> query = appDbContext.Employees;

	        if(!string.IsNullOrEmpty(name))
			{
				query = query.Where(e => (e.FirstName != null && e.FirstName.Contains(name)) || (e.LastName != null && e.LastName.Contains(name)));
			}

	        if(gender != null) query = query.Where(e => e.Gender == gender);

            return await query.ToListAsync();
        }
        #endregion
    }
}
