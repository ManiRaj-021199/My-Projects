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

        public async void DeleteEmployee(int nEmployeeId)
        {
            var result = GetEmployeeById(nEmployeeId).Result;
            
            if(result != null)
            {
                appDbContext.Employees.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Employee?> UpdateEmployee(Employee employee)
        {
            var result = GetEmployeeById(employee.EmployeeId).Result;

            if(result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBirth = employee.DateOfBirth;
                result.Gender = employee.Gender;
                result.DepartmentId = employee.DepartmentId;
                result.PhotoPath = employee.PhotoPath;

                await appDbContext.SaveChangesAsync();
            }

            return result;
        }
        #endregion
    }
}
