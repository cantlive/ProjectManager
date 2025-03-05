using Microsoft.EntityFrameworkCore;
using ProjectManager.DataAccess.Interfaces;
using ProjectManager.DataAccess.Models;

namespace ProjectManager.DataAccess.Repositories
{
    internal class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateProjectAsync(Project project, CancellationToken cancellationToken = default)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync(cancellationToken);
            return project.Id;
        }

        public async Task<Project> GetProjectByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Projects.Include(p => p.Employees)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<List<Project>> GetProjectsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Projects.Include(p => p.Employees).ToListAsync(cancellationToken);
        }

        public async Task UpdateProjectAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(Project project)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }

        public async Task AddEmployeeAsync(Project project, Employee employee)
        {
            project.Employees.Add(employee);
            employee.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(Project project, Employee employee)
        {
            project.Employees.Remove(employee);
            employee.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}
