using Microsoft.EntityFrameworkCore;
using ProjectManager.DataAccess.Interfaces;
using ProjectManager.DataAccess.Models;

namespace ProjectManager.DataAccess.Repositories
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateEmployeeAsync(Employee employee, CancellationToken cancellationToken = default)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(cancellationToken);
            return employee.Id;
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public async Task<List<Employee>> GetEmployeesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Employees.ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SearchedEmployee>> SearchAsync(string searchTerm)
        {
            return await _context.Employees
                .Where(e => e.FirstName.Contains(searchTerm) || e.LastName.Contains(searchTerm))
                .Select(e => new SearchedEmployee
                {
                    Id = e.Id,
                    FullName = e.FirstName + " " + e.LastName
                })
                .ToListAsync();
        }
    }
}
