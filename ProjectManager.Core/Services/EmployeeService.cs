using ProjectManager.Core.Exceptions;
using ProjectManager.Core.Interfaces;
using ProjectManager.Core.Models;
using ProjectManager.Core.Validators;
using ProjectManager.DataAccess.Interfaces;
using ProjectManager.DataAccess.Models;

namespace ProjectManager.Core.Services
{
    internal class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly CreateEmployeeValidator _createValidator = new CreateEmployeeValidator();
        private readonly UpdateEmployeeValidator _updateValidator = new UpdateEmployeeValidator();

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Guid> CreateEmployeeAsync(CreateEmployeeDto employeeDto, CancellationToken cancellationToken = default)
        {
            await _createValidator.ValidateAndThrowAsync(employeeDto);

            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                MiddleName = employeeDto.MiddleName,
                Email = employeeDto.Email
            };
            return await _employeeRepository.CreateEmployeeAsync(employee, cancellationToken);
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid employeeId, CancellationToken cancellationToken = default)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(employeeId, cancellationToken) 
                ?? throw new NotFoundException(nameof(Employee), employeeId);
        }

        public async Task<List<Employee>> GetEmployeesAsync(CancellationToken cancellationToken = default)
        {
            return await _employeeRepository.GetEmployeesAsync(cancellationToken);
        }

        public async Task UpdateEmployeeAsync(UpdateEmployeeDto employeeDto)
        {
            await _updateValidator.ValidateAndThrowAsync(employeeDto);

            var employee = await GetEmployeeByIdAsync(employeeDto.Id);
            if (employee == null)
                throw new NotFoundException(nameof(Employee), employeeDto.Id);

            employee.FirstName = employeeDto.FirstName;
            employee.LastName = employeeDto.LastName;
            employee.MiddleName = employeeDto.MiddleName;
            employee.Email = employeeDto.Email;

            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteEmployeeByIdAsync(Guid id)
        {
            var employee = await GetEmployeeByIdAsync(id);
            if (employee == null)
                throw new NotFoundException(nameof(Employee), id);

            await _employeeRepository.DeleteAsync(employee);
        }
    }
}
