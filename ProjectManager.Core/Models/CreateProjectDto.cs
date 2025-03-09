using Microsoft.AspNetCore.Http;
using ProjectManager.DataAccess.Models;

namespace ProjectManager.Core.Models
{
    public class CreateProjectDto
    {
        public string Name { get; set; }
        public string CustomerCompany { get; set; }
        public string ContractorCompany { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ProjectPriority Priority { get; set; }
        public Guid ProjectManagerId { get; set; }
        public List<Guid> EmployeeIds { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<string> FilePaths { get; set; }
    }
}
