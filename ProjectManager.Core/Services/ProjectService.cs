using ProjectManager.Core.Exceptions;
using ProjectManager.Core.Interfaces;
using ProjectManager.Core.Models;
using ProjectManager.Core.Validators;
using ProjectManager.DataAccess.Interfaces;
using ProjectManager.DataAccess.Models;

namespace ProjectManager.Core.Services
{
    internal class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly CreateProjectValidator _createValidator = new CreateProjectValidator();
        private readonly UpdateProjectValidator _updateValidator = new UpdateProjectValidator();

        public ProjectService(IProjectRepository projectRepository, IEmployeeRepository employeeRepository)
        {
            _projectRepository = projectRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<Guid> CreateProjectAsync(CreateProjectDto projectDto, CancellationToken cancellationToken = default)
        {
            await _createValidator.ValidateAndThrowAsync(projectDto);
            var employees = await _employeeRepository.GetEmployeesByIdsAsync(projectDto.EmployeeIds);

            var project = new Project
            {
                Id = Guid.NewGuid(),
                Name = projectDto.Name,
                CustomerCompany = projectDto.CustomerCompany,
                ContractorCompany = projectDto.ContractorCompany,
                StartDate = projectDto.StartDate,
                EndDate = projectDto.EndDate,
                PriorityEnum = projectDto.Priority,
                ProjectManagerId = projectDto.ProjectManagerId,
                ProjectManager = await _employeeRepository.GetEmployeeByIdAsync(projectDto.ProjectManagerId),
                Employees = employees.Select(e => new ProjectEmployee { EmployeeId = e.Id }).ToList(),
                FilePaths = projectDto.FilePaths
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
            await _updateValidator.ValidateAndThrowAsync(projectDto);

            var project = await GetProjectOrThrowAsync(projectDto.Id);
            var employees = await _employeeRepository.GetEmployeesByIdsAsync(projectDto.EmployeeIds);

            project.Id = projectDto.Id;
            project.Name = projectDto.Name;
            project.CustomerCompany = projectDto.CustomerCompany;
            project.ContractorCompany = projectDto.ContractorCompany;
            project.StartDate = projectDto.StartDate;
            project.EndDate = projectDto.EndDate;
            project.Priority = projectDto.Priority;
            project.ProjectManager = await _employeeRepository.GetEmployeeByIdAsync(projectDto.ProjectManagerId);
            project.ProjectManagerId = projectDto.ProjectManagerId;
            project.Employees = employees.Select(e => new ProjectEmployee { EmployeeId = e.Id }).ToList();

            await _projectRepository.UpdateProjectAsync(project);
        }

        public async Task DeleteProjectByIdAsync(Guid id)
        {
            var project = await GetProjectOrThrowAsync(id);
            await _projectRepository.DeleteProjectAsync(project);
        }

        public async Task AddEmployeeToProjectAsync(Guid projectId, Employee employee)
        {
            var project = await GetProjectOrThrowAsync(projectId);
            await _projectRepository.AddEmployeeAsync(project, employee);
        }

        public async Task RemoveEmployeeFromProjectAsync(Guid projectId, Employee employee)
        {
            var project = await GetProjectOrThrowAsync(projectId);
            await _projectRepository.DeleteEmployeeAsync(project, employee);
        }

        private async Task<Project> GetProjectOrThrowAsync(Guid id)
        {
            var project = await GetProjectByIdAsync(id);
            if (project == null)
                throw new NotFoundException(nameof(Project), id);

            return project;
        }
    }
}
