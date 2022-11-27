using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Employee Table
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@gmail.com",
                DateOfBirth = new DateTime(2000, 1, 1),
                Gender = Gender.Male,
                Department = 1,
                PhotoPath = "images/john.png"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "John",
                LastName = "Snow",
                Email = "johnsnow@gmail.com",
                DateOfBirth = new DateTime(2000, 2, 1),
                Gender = Gender.Male,
                Department = 2,
                PhotoPath = "images/sam.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                FirstName = "Mary",
                LastName = "William",
                Email = "mary@gmail.com",
                DateOfBirth = new DateTime(2000, 3, 1),
                Gender = Gender.Female,
                Department = 3,
                PhotoPath = "images/mary.png"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 4,
                FirstName = "Sara",
                LastName = "Longway",
                Email = "sara@gmail.com",
                DateOfBirth = new DateTime(2000, 5, 1),
                Gender = Gender.Female,
                Department = 4,
                PhotoPath = "images/sara.png"
            });
        }
    }
}
