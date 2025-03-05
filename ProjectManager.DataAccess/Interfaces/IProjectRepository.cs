using ProjectManager.DataAccess.Models;

namespace ProjectManager.DataAccess.Interfaces
{
    public interface IProjectRepository
    {
        Task<Guid> CreateProjectAsync(Project project, CancellationToken cancellationToken = default);
        Task<Project> GetProjectByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<Project>> GetProjectsAsync(CancellationToken cancellationToken = default);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(Project project);
        Task AddEmployeeAsync(Project project, Employee employee);
        Task DeleteEmployeeAsync(Project project, Employee employee);
    }
}
