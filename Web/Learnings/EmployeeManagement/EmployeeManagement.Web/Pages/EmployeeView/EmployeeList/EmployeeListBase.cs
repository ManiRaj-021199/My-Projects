using Microsoft.AspNetCore.Components;
using EmployeeManagement.Models;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        public IEnumerable<Employee>? Employees { get; set; }

        protected override Task OnInitializedAsync()
        {
            LoadEmployees();
            return base.OnInitializedAsync();
        }

        private void LoadEmployees()
        {
            Employee employee1 = new()
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@gmail.com",
                DateOfBirth = new DateTime(2000, 1, 1),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/john.png"
            };

            Employee employee2 = new()
            {
                EmployeeId = 2,
                FirstName = "John",
                LastName = "Snow",
                Email = "johnsnow@gmail.com",
                DateOfBirth = new DateTime(2000, 2, 1),
                Gender = Gender.Male,
                DepartmentId = 2,
                PhotoPath = "images/sam.jpg"
            };

            Employee employee3 = new()
            {
                EmployeeId = 3,
                FirstName = "Mary",
                LastName = "William",
                Email = "mary@gmail.com",
                DateOfBirth = new DateTime(2000, 3, 1),
                Gender = Gender.Female,
                DepartmentId = 3,
                PhotoPath = "images/mary.png"
            };

            Employee employee4 = new()
            {
                EmployeeId = 4,
                FirstName = "Sara",
                LastName = "Longway",
                Email = "sara@gmail.com",
                DateOfBirth = new DateTime(2000, 5, 1),
                Gender = Gender.Female,
                DepartmentId = 4,
                PhotoPath = "images/sara.png"
            };

            Employees = new List<Employee> { employee1, employee2, employee3, employee4 };
        }
    }
}
