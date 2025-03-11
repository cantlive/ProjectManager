using ProjectManager.DataAccess.Models;

namespace ProjectManager.Core.Models
{
    public class UpdateEmployeeDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }

        public UpdateEmployeeDto()
        {
            
        }

        public UpdateEmployeeDto(Employee employee)
        {
            Id = employee.Id;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            MiddleName = employee.MiddleName;
            Email = employee.Email;
        }
    }
}
