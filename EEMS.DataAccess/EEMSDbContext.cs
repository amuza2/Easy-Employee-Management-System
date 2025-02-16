using EEMS.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace EEMS.DataAccess
{
    public class EEMSDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<AbsenceType> AbsenceTypes { get; set; }
        public DbSet<DrivingLicenseType> DrivingLicenseTypes { get; set; }
        public DbSet<EmployeeDrivingLicense> EmployeeDrivingLicenses { get; set; }
        public DbSet<JobNature> JobNatures { get; set; }

        public EEMSDbContext() { }

        public EEMSDbContext(DbContextOptions<EEMSDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigHelper.GetConnectionString());
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One to Many: Department -> Employee
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);

            // One to Many: Project -> Employee
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Project)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.ProjectId);

            // One to Many: Employee -> Absence
            modelBuilder.Entity<Absence>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.Absences)
                .HasForeignKey(a => a.EmployeeId);

            // One to Many: AbsenceType -> Absence
            modelBuilder.Entity<Absence>()
                .HasOne(a => a.AbsenceType)
                .WithMany(ab => ab.Absences)
                .HasForeignKey(a => a.AbsenceTypeId);

            // Many to Many: Employee -> EmployeeDrivingLicense
            modelBuilder.Entity<EmployeeDrivingLicense>()
                .HasKey(ed => new { ed.EmployeeId, ed.DrivingLicenseTypeId });

            modelBuilder.Entity<EmployeeDrivingLicense>()
                .HasOne(edl => edl.Employee)
                .WithMany(e => e.EmployeeDrivingLicenses)
                .HasForeignKey(edl => edl.EmployeeId);

            modelBuilder.Entity<EmployeeDrivingLicense>()
                .HasOne(edl => edl.DrivingLicenseType)
                .WithMany(dlt => dlt.EmployeeDrivingLicenses)
                .HasForeignKey(edl => edl.DrivingLicenseTypeId);

            // One to Many: JobNature -> Employee
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.JobNature)
                .WithMany(j => j.Employees)
                .HasForeignKey(e => e.JobNatureId);
        }
    }
}
