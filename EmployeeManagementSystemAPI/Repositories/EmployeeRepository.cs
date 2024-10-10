using EmployeeManagementAPI.Data;
using EmployeeManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            try
            {
                return await _context.Employees.ToListAsync();
            }
            catch (Exception ex) 
            {
                throw new Exception("Unable to get all employees: " + ex.Message);
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            try
            {
                return await _context.Employees.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to fetch data against employee Id: " + ex.Message);
            }
        }

        public async Task AddEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to add employee: " + ex.Message);
            }
        }

        public async Task UpdateEmployee(Employee employee)
        {
            try
            {
                _context.Entry(employee).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to update employee: " + ex.Message);
            }
        }

        public async Task DeleteEmployee(int id)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to delete employee: " + ex.Message);
            }
        }
       
    }
}
