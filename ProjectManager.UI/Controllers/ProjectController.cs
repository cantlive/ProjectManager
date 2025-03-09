using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManager.Core.Interfaces;
using ProjectManager.Core.Models;
using ProjectManager.DataAccess.Models;
using ProjectManager.UI.ViewModels;

namespace ProjectManager.UI.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await _projectService.GetProjectsAsync();
            var viewModel = new ProjectListViewModel { Projects = projects };
            return View(viewModel);
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

            var updateDto = new UpdateProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                CustomerCompany = project.CustomerCompany,
                ContractorCompany = project.ContractorCompany,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Priority = project.Priority,
                ProjectManagerId = project.ProjectManager.Id,
                EmployeeIds = project.Employees.Select(x => x.Id).ToList()
            };

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
                    Value = e.Id.ToString(),
                    Text = e.FullName,
                    Selected = project.Employees.Any(emp => emp.Id == e.Id)
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
    }
}
