using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProjectManager.DataAccess.Models
{
    public class Project
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string CustomerCompany { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string ContractorCompany { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int Priority { get; set; }

        [NotMapped]
        public ProjectPriority PriorityEnum
        {
            get => (ProjectPriority)Priority;
            set => Priority = (int)value;
        }

        [Required]
        public Guid ProjectManagerId { get; set; }

        [ForeignKey("ProjectManagerId")]
        public Employee ProjectManager { get; set; }

        public List<ProjectEmployee> Employees { get; set; } = new List<ProjectEmployee>();

        
        public List<string> FilePaths { get; set; } = new List<string>();
    }
}
