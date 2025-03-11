using ProjectManager.DataAccess.Models;

namespace ProjectManager.Core.Models
{
    public class ProjectListDto
    {
        public string ProjectName { get; set; }
        public DateTime? StartDateFrom { get; set; }
        public DateTime? StartDateTo { get; set; }
        public ProjectPriority? Priority { get; set; }
        public string SortBy { get; set; }
        public List<Project> Projects { get; set; }
    }
}
