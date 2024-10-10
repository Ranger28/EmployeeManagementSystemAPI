using EmployeeManagementSystemAPI.Models;

namespace EmployeeManagementAPI.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees;

        public EmployeeRepository()
        {
            _employees = new List<Employee>
            {
                new Employee { Id = 1, FirstName = "Malik",  MiddleName = "Fahad", LastName = "Azeem"},
                new Employee { Id = 2, FirstName = "Chris",  MiddleName = "John", LastName = "Angel"},
                new Employee { Id = 3, FirstName = "Ali",  MiddleName = "Ahmed", LastName = "Usman"},
                new Employee { Id = 4, FirstName = "Overton",  MiddleName = "Shane", LastName = "Watson"},
                new Employee { Id = 5, FirstName = "Prem",  MiddleName = "Lalit", LastName = "Kumar"},
            };
        }

        public List<Employee> GetAllEmployees()
        {
            return _employees;   
        }

        public Employee GetEmployeeById(int id)
        {
            try
            {
                return _employees.FirstOrDefault(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to fetch data against employee Id: " + ex.Message);
            }
        }

        public void AddEmployee(Employee employee)
        {
            try
            {
                employee.Id = _employees.Max(e => e.Id) + 1;
                _employees.Add(employee);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to add employee: " + ex.Message);
            }
        }

        public void UpdateEmployee(Employee updatedEmployee)
        {
            try
            {
                var employee = _employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);
                if (employee != null)
                {
                    employee.FirstName = updatedEmployee.FirstName;
                    employee.LastName = updatedEmployee.LastName;
                    employee.MiddleName = updatedEmployee.MiddleName;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to update employee: " + ex.Message);
            }
        }

        public void DeleteEmployee(int id)
        {
            try
            {
                var employee = _employees.FirstOrDefault(e => e.Id == id);
                if (employee != null)
                {
                    _employees.Remove(employee);
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("Unable to delete employee: " + ex.Message);
            }
        }
    }
}
