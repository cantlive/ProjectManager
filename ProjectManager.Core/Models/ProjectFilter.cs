using ProjectManager.DataAccess.Models;

namespace ProjectManager.Core.Models
{
    public class ProjectFilter
    {
        public string ProjectName { get; set; }
        public DateTime? StartDateFrom { get; set; }
        public DateTime? StartDateTo { get; set; }
        public ProjectPriority? Priority { get; set; }

        public ProjectFilter(string projectName, DateTime? startDateFrom, DateTime? startDateTo, ProjectPriority? priority)
        {
            ProjectName = projectName;
            StartDateFrom = startDateFrom;
            StartDateTo = startDateTo;
            Priority = priority;
        }
    }
}
