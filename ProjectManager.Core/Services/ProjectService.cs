using ProjectManager.Core.Interfaces;
using ProjectManager.Core.Models;
using ProjectManager.DataAccess.Interfaces;
using ProjectManager.DataAccess.Models;

namespace ProjectManager.Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Guid> CreateProjectAsync(CreateProjectDto projectDto, CancellationToken cancellationToken = default)
        {
            var project = new Project
            {
                Id = Guid.NewGuid(),
                Name = projectDto.Name,
                CustomerCompany = projectDto.CustomerCompany,
                ContractorCompany = projectDto.ContractorCompany,
                StartDate = projectDto.StartDate,
                EndDate = projectDto.EndDate,
                Priority = projectDto.Priority,
                ProjectManagerId = projectDto.ProjectManager.Id,
                ProjectManager = projectDto.ProjectManager,
                Employees = projectDto.Employees
            };
            return await _projectRepository.CreateProjectAsync(project, cancellationToken);
        }

        public async Task<Project> GetProjectByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _projectRepository.GetProjectByIdAsync(id, cancellationToken);
        }

        public async Task<List<Project>> GetProjectsAsync(CancellationToken cancellationToken = default)
        {
            return await _projectRepository.GetProjectsAsync(cancellationToken);
        }

        public async Task UpdateProjectAsync(UpdateProjectDto projectDto)
        {
            var project = new Project
            {
                Id = projectDto.Id,
                Name = projectDto.Name,
                CustomerCompany = projectDto.CustomerCompany,
                ContractorCompany = projectDto.ContractorCompany,
                StartDate = projectDto.StartDate,
                EndDate = projectDto.EndDate,
                Priority = projectDto.Priority
            };
            await _projectRepository.UpdateProjectAsync(project);
        }

        public async Task DeleteProjectByIdAsync(Guid id)
        {
            await _projectRepository.DeleteProjectByIdAsync(id);
        }

        public async Task AddEmployeeToProjectAsync(Guid projectId, Employee employee)
        {
            await _projectRepository.AddEmployeeAsync(projectId, employee);
        }

        public async Task RemoveEmployeeFromProjectAsync(Guid projectId, Guid employeeId)
        {
            await _projectRepository.DeleteEmployeeByIdAsync(projectId, employeeId);
        }
    }
}
