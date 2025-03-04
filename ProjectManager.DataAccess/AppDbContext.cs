using Microsoft.EntityFrameworkCore;
using ProjectManager.DataAccess.EntityTypeConfigurations;
using ProjectManager.DataAccess.Models;

namespace ProjectManager.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProjectConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
