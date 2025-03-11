using ProjectManager.DataAccess.Models;

namespace ProjectManager.Core.Models
{
    public class ProjectListDto
    {
        public List<Project> Projects { get; set; }
        public ProjectFilter Filter { get; set; }
        public string SortBy { get; set; }

        public ProjectListDto(List<Project> projects, ProjectFilter filter, string sortBy)
        {
            Projects = projects;
            Filter = filter;
            SortBy = sortBy;
        }
    }
}
