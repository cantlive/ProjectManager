using ProjectManager.DataAccess.Models;

namespace ProjectManager.DataAccess.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Guid> CreateEmployeeAsync(Employee employee, CancellationToken cancellationToken = default);
        Task<Employee> GetEmployeeByIdAsync(Guid employeeId, CancellationToken cancellationToken = default);
        Task<Employee> GetEmployeesAsync(CancellationToken cancellationToken = default);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(Guid id);
    }
}
