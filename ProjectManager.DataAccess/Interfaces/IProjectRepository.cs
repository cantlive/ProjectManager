using ProjectManager.DataAccess.Models;

namespace ProjectManager.DataAccess.Interfaces
{
    public interface IProjectRepository
    {
        Task<Guid> CreateProjectAsync(Project project, CancellationToken cancellationToken = default);
        Task<Project> GetProjectByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<Project>> GetProjectsAsync(CancellationToken cancellationToken = default);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectByIdAsync(Guid id);
        Task AddEmployeeAsync(Guid projectId, Employee employee);
        Task DeleteEmployeeByIdAsync(Guid projectId, Guid employeeId);
    }
}
