using ProjectManager.Core.Models;
using ProjectManager.DataAccess.Models;

namespace ProjectManager.Core.Interfaces
{
    public interface IProjectService
    {
        Task<Guid> CreateProjectAsync(CreateProjectDto projectDto, CancellationToken cancellationToken = default);
        Task<Project> GetProjectByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<Project>> GetProjectsAsync(CancellationToken cancellationToken = default);
        Task UpdateProjectAsync(UpdateProjectDto projectDto);
        Task DeleteProjectByIdAsync(Guid id);
        Task AddEmployeeToProjectAsync(Guid projectId, Employee employee);
        Task RemoveEmployeeFromProjectAsync(Guid projectId, Guid employeeId);
    }
}
