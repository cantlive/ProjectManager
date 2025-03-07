using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Interfaces;
using ProjectManager.Core.Models;

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
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _employeeService.CreateEmployeeAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null) return NotFound();

            var updateDto = new UpdateEmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateEmployeeDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _employeeService.UpdateEmployeeAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _employeeService.DeleteEmployeeByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
