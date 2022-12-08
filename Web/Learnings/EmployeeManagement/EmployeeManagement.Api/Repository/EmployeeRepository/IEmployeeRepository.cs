using EmployeeManagement.Models;

namespace EmployeeManagement.Api.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee?> GetEmployeeById(int nEmployeeId);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee?> UpdateEmployee(Employee employee);
        Task<Employee?> DeleteEmployee(int nEmployeeId);
        Task<IEnumerable<Employee>> SearchEmployees(string name, Gender? gender);
    }
}
