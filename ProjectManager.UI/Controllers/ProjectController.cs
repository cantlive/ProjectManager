using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManager.Core.Interfaces;
using ProjectManager.Core.Models;
using ProjectManager.DataAccess.Models;
using ProjectManager.UI.Models;
using System.Diagnostics;

namespace ProjectManager.UI.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IActionResult> Index(string projectName, DateTime? startDateFrom, DateTime? startDateTo, ProjectPriority? priority, string sortBy)
        {
            var filter = new ProjectFilter(projectName, startDateFrom, startDateTo, priority);
            var projects = await _projectService.GetProjectsAsync(filter, sortBy);
            var projectListDto = new ProjectListDto(projects, filter, sortBy);

            return View(projectListDto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectDto dto)
        {
            await _projectService.CreateProjectAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            var updateDto = new UpdateProjectDto(project);

            var selectedProjectManager = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = project.ProjectManager.Id.ToString(),
                    Text = project.ProjectManager.FullName,
                    Selected = true
                }
            };

            var selectedEmployees = project.Employees
                .Select(e => new SelectListItem
                {
                    Value = e.EmployeeId.ToString(),
                    Text = e.Employee.FullName,
                    Selected = project.Employees.Any(emp => emp.EmployeeId == e.EmployeeId)
                })
                .ToList();

            ViewBag.ProjectManagers = selectedProjectManager;
            ViewBag.Employees = selectedEmployees;

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProjectDto dto)
        {
            await _projectService.UpdateProjectAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _projectService.DeleteProjectByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
