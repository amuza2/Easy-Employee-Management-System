﻿// <auto-generated />
using System;
using EEMS.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EEMS.DataAccess.Migrations
{
    [DbContext(typeof(EEMSDbContext))]
    [Migration("20250309101500_AddAndEditTables")]
    partial class AddAndEditTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EEMS.DataAccess.Models.Absence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AbsenceTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Days")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AbsenceTypeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Absences");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.AbsenceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AbsenceTypes");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.Diploma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DateIssued")
                        .HasColumnType("date");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TrainingId");

                    b.ToTable("Diplomas");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.DrivingLicenseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DrivingLicenseTypes");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BirthLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EssentialTraining")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("FamilySituation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("JobNatureId")
                        .HasColumnType("int");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguagesSpoken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LeaveId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RecruitmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Residence")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Training")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("JobNatureId");

                    b.HasIndex("LeaveId")
                        .IsUnique()
                        .HasFilter("[LeaveId] IS NOT NULL");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.EmployeeDrivingLicense", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("DrivingLicenseTypeId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "DrivingLicenseTypeId");

                    b.HasIndex("DrivingLicenseTypeId");

                    b.ToTable("EmployeeDrivingLicenses");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.EmployeeTraining", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "TrainingId");

                    b.HasIndex("TrainingId");

                    b.ToTable("EmployeesTraining");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.JobNature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobNatures");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.Leave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LeaveDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Leaves");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.Sanction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DateHappened")
                        .HasColumnType("date");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Panishement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Sanctions");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Length")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.Vacation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Vacations");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.Absence", b =>
                {
                    b.HasOne("EEMS.DataAccess.Models.AbsenceType", "AbsenceType")
                        .WithMany("Absences")
                        .HasForeignKey("AbsenceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EEMS.DataAccess.Models.Employee", "Employee")
                        .WithMany("Absences")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AbsenceType");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.Diploma", b =>
                {
                    b.HasOne("EEMS.DataAccess.Models.Employee", "Employee")
                        .WithMany("Diplomas")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EEMS.DataAccess.Models.Training", "Training")
                        .WithMany("Diplomas")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Training");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.Employee", b =>
                {
                    b.HasOne("EEMS.DataAccess.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("EEMS.DataAccess.Models.JobNature", "JobNature")
                        .WithMany("Employees")
                        .HasForeignKey("JobNatureId");

                    b.HasOne("EEMS.DataAccess.Models.Leave", "Leave")
                        .WithOne("Employee")
                        .HasForeignKey("EEMS.DataAccess.Models.Employee", "LeaveId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Department");

                    b.Navigation("JobNature");

                    b.Navigation("Leave");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.EmployeeDrivingLicense", b =>
                {
                    b.HasOne("EEMS.DataAccess.Models.DrivingLicenseType", "DrivingLicenseType")
                        .WithMany("EmployeeDrivingLicenses")
                        .HasForeignKey("DrivingLicenseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EEMS.DataAccess.Models.Employee", "Employee")
                        .WithMany("EmployeeDrivingLicenses")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DrivingLicenseType");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.EmployeeTraining", b =>
                {
                    b.HasOne("EEMS.DataAccess.Models.Employee", "Employee")
                        .WithMany("EmployeesTraining")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EEMS.DataAccess.Models.Training", "Training")
                        .WithMany("EmployeesTraining")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Training");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.Sanction", b =>
                {
                    b.HasOne("EEMS.DataAccess.Models.Employee", "Employee")
                        .WithMany("Sanctions")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.Vacation", b =>
                {
                    b.HasOne("EEMS.DataAccess.Models.Employee", "Employee")
                        .WithMany("Vacations")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.AbsenceType", b =>
                {
                    b.Navigation("Absences");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.DrivingLicenseType", b =>
                {
                    b.Navigation("EmployeeDrivingLicenses");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.Employee", b =>
                {
                    b.Navigation("Absences");

                    b.Navigation("Diplomas");

                    b.Navigation("EmployeeDrivingLicenses");

                    b.Navigation("EmployeesTraining");

                    b.Navigation("Sanctions");

                    b.Navigation("Vacations");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.JobNature", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.Leave", b =>
                {
                    b.Navigation("Employee")
                        .IsRequired();
                });

            modelBuilder.Entity("EEMS.DataAccess.Models.Training", b =>
                {
                    b.Navigation("Diplomas");

                    b.Navigation("EmployeesTraining");
                });
#pragma warning restore 612, 618
        }
    }
}
