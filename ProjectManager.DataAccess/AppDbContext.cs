using Microsoft.EntityFrameworkCore;
using ProjectManager.DataAccess.EntityTypeConfigurations;
using ProjectManager.DataAccess.Models;
using System.Reflection.Emit;
using System.Runtime.InteropServices.Marshalling;

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

            builder.Entity<Project>().Property(m => m.FilePaths).IsRequired(false);

            builder.Entity<ProjectEmployee>()
                .HasKey(pe => new { pe.ProjectId, pe.EmployeeId });

            builder.Entity<ProjectEmployee>()
                .HasOne(pe => pe.Project)
                .WithMany(p => p.Employees)
                .HasForeignKey(pe => pe.ProjectId);

            builder.Entity<ProjectEmployee>()
                .HasOne(pe => pe.Employee)
                .WithMany(e => e.ProjectEmployees)
                .HasForeignKey(pe => pe.EmployeeId);
        }
    }
}
