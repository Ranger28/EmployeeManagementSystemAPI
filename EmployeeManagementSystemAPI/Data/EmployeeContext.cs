using EmployeeManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "Malik", MiddleName = "Fahad", LastName = "Azeem" },
                new Employee { Id = 2, FirstName = "Chris", MiddleName = "John", LastName = "Angel" },
                new Employee { Id = 3, FirstName = "Ali", MiddleName = "Ahmed", LastName = "Usman" },
                new Employee { Id = 4, FirstName = "Overton", MiddleName = "Shane", LastName = "Watson" },
                new Employee { Id = 5, FirstName = "Prem", MiddleName = "Lalit", LastName = "Kumar" }
            );
        }
    }
}
