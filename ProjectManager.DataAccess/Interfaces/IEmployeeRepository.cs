using ProjectManager.DataAccess.Models;

namespace ProjectManager.DataAccess.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Guid> CreateEmployeeAsync(Employee employee, CancellationToken cancellationToken = default);
        Task<Employee> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<Employee>> GetEmployeesAsync(CancellationToken cancellationToken = default);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(Employee employee);
        Task<List<SearchedEmployee>> SearchAsync(string searchTerm);
    }
}
