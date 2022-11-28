using EmployeeManagement.Models;

namespace EmployeeManagement.Api.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee?> GetEmployeeById(int nEmployeeId);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee?> UpdateEmployee(Employee employee);
        void DeleteEmployee(int nEmployeeId);
    }
}
