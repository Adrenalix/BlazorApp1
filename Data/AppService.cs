using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class AppService
    {
        private readonly AppDbContext _context;

        public AppService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<List<Employee>> GetEmployeeList()
        {
            var Employees = new List<Employee>();
            AppDbContext context = new AppDbContext();
            Employees = context.Employee.Include(a => a.Department).ToList();
            return await Task.FromResult(Employees);
        }

        public async Task<List<Department>> GetDepartmentList()
        {
            var Departments = new List<Department>();
            AppDbContext context = new AppDbContext();
            Departments = context.Department.ToList();
            return await Task.FromResult(Departments);
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee updatedEmployee)
        {
            var existingEmployee = await _context.Employee
                .FirstOrDefaultAsync(e => e.EmployeeId == updatedEmployee.EmployeeId);

            if (existingEmployee != null)
            {
                existingEmployee.FirstName = updatedEmployee.FirstName;
                existingEmployee.LastName = updatedEmployee.LastName;
                existingEmployee.DepartmentId = updatedEmployee.DepartmentId;

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Employee with ID {updatedEmployee.EmployeeId} does not exist.");
            }
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee != null)
            {
                _context.Employee.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
