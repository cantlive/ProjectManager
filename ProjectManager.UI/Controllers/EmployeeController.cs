using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Interfaces;
using ProjectManager.Core.Models;
using ProjectManager.UI.Models;
using System.Diagnostics;

namespace ProjectManager.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            var employeeListDto = new EmployeeListDto { Employees = employees };

            return View(employeeListDto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeDto dto)
        {
            await _employeeService.CreateEmployeeAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            var updateDto = new UpdateEmployeeDto(employee);

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateEmployeeDto dto)
        {
            await _employeeService.UpdateEmployeeAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _employeeService.DeleteEmployeeByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search(string searchTerm)
        {
            var employees = await _employeeService.SearchAsync(searchTerm);
            return Ok(employees);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
