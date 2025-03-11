using ProjectManager.DataAccess.Models;

namespace ProjectManager.Core.Models
{
    public class UpdateProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CustomerCompany { get; set; }
        public string ContractorCompany { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public Guid ProjectManagerId { get; set; }
        public List<Guid> EmployeeIds { get; set; }

        public UpdateProjectDto()
        {
            
        }

        public UpdateProjectDto(Project project)
        {
            Id = project.Id;
            Name = project.Name;
            CustomerCompany = project.CustomerCompany;
            ContractorCompany = project.ContractorCompany;
            StartDate = project.StartDate;
            EndDate = project.EndDate;
            Priority = project.Priority;
            ProjectManagerId = project.ProjectManager.Id;
            EmployeeIds = project.Employees.Select(x => x.EmployeeId).ToList();
        }
    }
}
