using ProjectManager.Core.Models;
using ProjectManager.DataAccess.Models;

namespace ProjectManager.Core.Interfaces
{
    public interface IEmployeeService
    {
        Task<Guid> CreateEmployeeAsync(CreateEmployeeDto employeeDto, CancellationToken cancellationToken = default);
        Task<Employee> GetEmployeeByIdAsync(Guid employeeId, CancellationToken cancellationToken = default);
        Task<List<Employee>> GetEmployeesAsync(CancellationToken cancellationToken = default);
        Task UpdateEmployeeAsync(UpdateEmployeeDto employeeDto);
        Task DeleteEmployeeByIdAsync(Guid id);
        Task<List<SearchedEmployee>> SearchAsync(string searchTerm);
    }
}
