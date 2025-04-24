using EEMS.Utilities.Enums;
using EEMS.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace EEMS.DataAccess;

public class EEMSDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Absence> Absences { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<JobNature> JobNatures { get; set; }
    //public DbSet<AbsenceType> AbsenceTypes { get; set; }
    //public DbSet<DrivingLicenseType> DrivingLicenseTypes { get; set; }
    //public DbSet<EmployeeDrivingLicense> EmployeeDrivingLicenses { get; set; }
    //public DbSet<Vacation> Vacations { get; set; }
    //public DbSet<Leave> Leaves { get; set; }
    //public DbSet<EmployeeTraining> EmployeesTraining { get; set; }
    //public DbSet<Training> Trainings { get; set; }
    //public DbSet<Diploma> Diplomas { get; set; }
    //public DbSet<Sanction> Sanctions { get; set; }

    public EEMSDbContext() { }

    public EEMSDbContext(DbContextOptions<EEMSDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(ConfigHelper.GetConnectionString());
        }
        optionsBuilder.UseLazyLoadingProxies();
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

        // One to Many: Employee -> Absence
        modelBuilder.Entity<Absence>()
            .HasOne(a => a.Employee)
            .WithMany(e => e.Absences)
            .HasForeignKey(a => a.EmployeeId);

        //// One to Many: AbsenceType -> Absence
        //modelBuilder.Entity<Absence>()
        //    .HasOne(a => a.AbsenceType)
        //    .WithMany(ab => ab.Absences)
        //    .HasForeignKey(a => a.AbsenceTypeId);

        // Many to Many: Employee -> EmployeeDrivingLicense
        //modelBuilder.Entity<EmployeeDrivingLicense>()
        //    .HasKey(ed => new { ed.EmployeeId, ed.DrivingLicenseTypeId });

        //modelBuilder.Entity<EmployeeDrivingLicense>()
        //    .HasOne(edl => edl.Employee)
        //    .WithMany(e => e.EmployeeDrivingLicenses)
        //    .HasForeignKey(edl => edl.EmployeeId);

        //modelBuilder.Entity<EmployeeDrivingLicense>()
        //    .HasOne(edl => edl.DrivingLicenseType)
        //    .WithMany(dlt => dlt.EmployeeDrivingLicenses)
        //    .HasForeignKey(edl => edl.DrivingLicenseTypeId);

        // One to Many: JobNature -> Employee
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.JobNature)
            .WithMany(j => j.Employees)
            .HasForeignKey(e => e.JobNatureId);

        modelBuilder.Entity<Employee>()
            .Property(e => e.Gender)
            .HasConversion<string>();

        modelBuilder.Entity<Employee>()
            .Property(e => e.FamilySituation)
            .HasConversion<string>();

        modelBuilder.Entity<Employee>()
            .Property(e => e.IsActive)
            .HasConversion<string>();

        // One to Many: Employee -> Vacation
        //modelBuilder.Entity<Vacation>()
        //    .HasOne(v => v.Employee)
        //    .WithMany(e => e.Vacations)
        //    .HasForeignKey(v => v.EmployeeId);

        //modelBuilder.Entity<Vacation>()
        //    .Property(v => v.StartDate)
        //    .HasColumnType("date");

        //One to One: Employee->Leave
        //modelBuilder.Entity<Employee>()
        //    .HasOne(e => e.Leave)
        //    .WithOne(l => l.Employee)
        //    .HasForeignKey<Employee>(e => e.LeaveId)
        //    .IsRequired(false)
        //    .OnDelete(DeleteBehavior.SetNull);

        // Many to Many: Employee -> EmployeeTraining
        //modelBuilder.Entity<EmployeeTraining>()
        //    .HasKey(et => new { et.EmployeeId, et.TrainingId });

        //modelBuilder.Entity<EmployeeTraining>()
        //    .HasOne(et => et.Employee)
        //    .WithMany(e => e.EmployeesTraining)
        //    .HasForeignKey(et => et.EmployeeId);

        //modelBuilder.Entity<EmployeeTraining>()
        //    .HasOne(et => et.Training)
        //    .WithMany(t => t.EmployeesTraining)
        //    .HasForeignKey(et => et.TrainingId);

        //modelBuilder.Entity<Training>()
        //    .Property(t => t.StartDate)
        //    .HasColumnType("date");

        // One to Many: Employee -> Diploma
        //modelBuilder.Entity<Diploma>()
        //    .HasOne(d => d.Employee)
        //    .WithMany(e => e.Diplomas)
        //    .HasForeignKey(d => d.EmployeeId);

        // One to Many: Training -> Diploma
        //modelBuilder.Entity<Diploma>()
        //    .HasOne(d => d.Training)
        //    .WithMany(t => t.Diplomas)
        //    .HasForeignKey(d => d.TrainingId);

        //modelBuilder.Entity<Diploma>()
        //    .Property(d => d.DateIssued)
        //    .HasColumnType("date");

        // One to Many: Employee -> Senction
        //modelBuilder.Entity<Sanction>()
        //    .HasOne(s => s.Employee)
        //    .WithMany(e => e.Sanctions)
        //    .HasForeignKey(s => s.EmployeeId);

        //modelBuilder.Entity<Sanction>()
        //    .Property(s => s.DateHappened)
        //    .HasColumnType("date");


        // Data seeding

        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Human Resources" },
            new Department { Id = 2, Name = "Budget and Accounting" },
            new Department { Id = 3, Name = "General Administration" }
            );

        //modelBuilder.Entity<Project>().HasData(
        //    new Project { Id = 1, Name = "Gas maintanance", Place = "Tamanraset" },
        //    new Project { Id = 2, Name = "Gas Finding", Place = "Ain Salah" },
        //    new Project { Id = 3, Name = "Gas Tube Manufacture", Place = "Djanat" }
        //    );

        modelBuilder.Entity<JobNature>().HasData(
            new JobNature { Id = 1, Name = "Full-time Work" },
            new JobNature { Id = 2, Name = "Part-time Work" },
            new JobNature { Id = 3, Name = "Temporary Work" }
            );

        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                FirstName = "أحمد",
                LastName = "الزيدي",
                Phone = "0599988776",
                JobTitle = "مهندس برمجيات",
                Email = "ahmad@example.com",
                Training = "تدريب في تطوير الويب",
                DateOfBirth = new DateTime(1995, 5, 12),
                BirthLocation = "الرياض",
                Address = "شارع الملك عبدالعزيز، الرياض",
                FamilySituation = FamilySituation.Single,
                RecruitmentDate = new DateTime(2022, 1, 10),
                Gender = Gender.Male,
                EssentialTraining = "ASP.NET Core",
                LanguagesSpoken = "العربية، الإنجليزية",
                Experience = 3,
                Residence = "الرياض",
                IsActive = Status.Active,
                IsArchived = false,
                DepartmentId = 1,
                JobNatureId = 1
            },
            new Employee
            {
                Id = 2,
                FirstName = "سارة",
                LastName = "العتيبي",
                Phone = "0501122334",
                JobTitle = "محللة نظم",
                Email = "sara@example.com",
                Training = "تحليل نظم المعلومات",
                DateOfBirth = new DateTime(1992, 11, 3),
                BirthLocation = "جدة",
                Address = "حي الشاطئ، جدة",
                FamilySituation = FamilySituation.Married,
                RecruitmentDate = new DateTime(2021, 7, 5),
                Gender = Gender.Female,
                EssentialTraining = "UML، تحليل البيانات",
                LanguagesSpoken = "العربية",
                Experience = 5,
                Residence = "جدة",
                IsActive = Status.Active,
                IsArchived = false,
                DepartmentId = 2,
                JobNatureId = 2
            },
            new Employee
            {
                Id = 3,
                FirstName = "خالد",
                LastName = "العنزي",
                Phone = "0567788990",
                JobTitle = "مدير مشاريع",
                Email = "khaled.anazi@example.com",
                Training = "إدارة المشاريع الاحترافية (PMP)",
                DateOfBirth = new DateTime(1988, 3, 20),
                BirthLocation = "الدمام",
                Address = "حي الفيصلية، الدمام",
                FamilySituation = FamilySituation.Married,
                RecruitmentDate = new DateTime(2020, 9, 15),
                Gender = Gender.Male,
                EssentialTraining = "إدارة فرق العمل، PMP",
                LanguagesSpoken = "العربية، الإنجليزية",
                Experience = 10,
                Residence = "الدمام",
                IsActive = Status.Active,
                IsArchived = false,
                DepartmentId = 3,
                JobNatureId = 1
            },
            new Employee
            {
                Id = 4,
                FirstName = "ندى",
                LastName = "الحربي",
                Phone = "0553344556",
                JobTitle = "مصممة جرافيك",
                Email = "nada.harbi@example.com",
                Training = "دورات Adobe و UI/UX",
                DateOfBirth = new DateTime(1996, 8, 12),
                BirthLocation = "مكة",
                Address = "حي العزيزية، مكة",
                FamilySituation = FamilySituation.Single,
                RecruitmentDate = new DateTime(2023, 2, 1),
                Gender = Gender.Female,
                EssentialTraining = "Adobe Photoshop، Figma",
                LanguagesSpoken = "العربية، الإنجليزية",
                Experience = 2,
                Residence = "مكة",
                IsActive = Status.Active,
                IsArchived = false,
                DepartmentId = 3,
                JobNatureId = 2
            },
            new Employee
            {
                Id = 5,
                FirstName = "فهد",
                LastName = "الشهري",
                Phone = "0531122334",
                JobTitle = "أخصائي شبكات",
                Email = "fahad.shahri@example.com",
                Training = "CCNA، أمن الشبكات",
                DateOfBirth = new DateTime(1990, 12, 25),
                BirthLocation = "أبها",
                Address = "حي المنسك، أبها",
                FamilySituation = FamilySituation.Married,
                RecruitmentDate = new DateTime(2019, 5, 18),
                Gender = Gender.Male,
                EssentialTraining = "أمن الشبكات",
                LanguagesSpoken = "العربية",
                Experience = 8,
                Residence = "أبها",
                IsActive = Status.Inactive,
                IsArchived = false,
                DepartmentId = 2,
                JobNatureId = 1
            },
            new Employee
            {
                Id = 6,
                FirstName = "ريم",
                LastName = "السبيعي",
                Phone = "0504455667",
                JobTitle = "أخصائية موارد بشرية",
                Email = "reem.subaie@example.com",
                Training = "إدارة الموارد البشرية، تقييم الأداء",
                DateOfBirth = new DateTime(1994, 6, 2),
                BirthLocation = "الخبر",
                Address = "حي اليرموك، الخبر",
                FamilySituation = FamilySituation.Divorced,
                RecruitmentDate = new DateTime(2021, 11, 10),
                Gender = Gender.Female,
                EssentialTraining = "تخطيط الموارد، تقييم الأداء",
                LanguagesSpoken = "العربية، الإنجليزية",
                Experience = 4,
                Residence = "الخبر",
                IsActive = Status.Active,
                IsArchived = false,
                DepartmentId = 1,
                JobNatureId = 1
            },
            new Employee
            {
                Id = 7,
                FirstName = "مازن",
                LastName = "اليامي",
                Phone = "0542211334",
                JobTitle = "محاسب",
                Email = "mazen.yami@example.com",
                Training = "معايير IFRS، تدقيق داخلي",
                DateOfBirth = new DateTime(1985, 9, 8),
                BirthLocation = "نجران",
                Address = "حي النهضة، نجران",
                FamilySituation = FamilySituation.Widowed,
                RecruitmentDate = new DateTime(2018, 3, 1),
                Gender = Gender.Male,
                EssentialTraining = "تدقيق مالي",
                LanguagesSpoken = "العربية",
                Experience = 12,
                Residence = "نجران",
                IsActive = Status.Active,
                IsArchived = false,
                DepartmentId = 3,
                JobNatureId = 3
            }


            );



    }
}
