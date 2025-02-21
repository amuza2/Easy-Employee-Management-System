using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EEMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedEmployeeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Employees_EmployeeId",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDrivingLicenses_Employees_EmployeeId",
                table: "EmployeeDrivingLicenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_JobNatures_JobNatureId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Projects_ProjectId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "jobNature");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ProjectId",
                table: "jobNature",
                newName: "IX_jobNature_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_JobNatureId",
                table: "jobNature",
                newName: "IX_jobNature_JobNatureId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentId",
                table: "jobNature",
                newName: "IX_jobNature_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_jobNature",
                table: "jobNature",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Human Resources" },
                    { 2, "Budget and Accounting" },
                    { 3, "General Administration" }
                });

            migrationBuilder.InsertData(
                table: "JobNatures",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Full-time Work" },
                    { 2, "Part-time Work" },
                    { 3, "Temporary Work" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name", "Place" },
                values: new object[,]
                {
                    { 1, "Gas maintanance", "Tamanraset" },
                    { 2, "Gas Finding", "Ain Salah" },
                    { 3, "Gas Tube Manufacture", "Djanat" }
                });

            migrationBuilder.InsertData(
                table: "jobNature",
                columns: new[] { "Id", "Address", "BirthLocation", "DateOfBirth", "DepartmentId", "Email", "EssentialTraining", "Experience", "FamilySituation", "FirstName", "Gender", "IsActive", "IsDeleted", "JobNatureId", "JobTitle", "LanguagesSpoken", "LastName", "Phone", "ProjectId", "RecruitmentDate", "Residence", "Training" },
                values: new object[,]
                {
                    { 1, "123 Main St, New York, USA", "New York, USA", new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "john.doe@example.com", null, null, "Single", "John", 0, true, false, 1, "Software Engineer", null, "Doe", "123-456-7890", 1, new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "New York, USA", "C#, .NET, SQL" },
                    { 2, "456 Elm St, Los Angeles, USA", "Los Angeles, USA", new DateTime(1985, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "jane.smith@example.com", null, null, "Married", "Jane", 1, true, false, 2, "Project Manager", null, "Smith", "987-654-3210", 2, new DateTime(2018, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Los Angeles, USA", "PMP, Agile, Scrum" },
                    { 3, "789 Oak St, Chicago, USA", "Chicago, USA", new DateTime(1992, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "alice.johnson@example.com", null, null, "Single", "Alice", 1, true, false, 3, "QA Engineer", null, "Johnson", "555-123-4567", 1, new DateTime(2021, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago, USA", "Selenium, Manual Testing" },
                    { 4, "321 Pine St, Houston, USA", "Houston, USA", new DateTime(1988, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "bob.brown@example.com", null, null, "Married", "Bob", 0, true, false, 1, "DevOps Engineer", null, "Brown", "444-555-6666", 3, new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Houston, USA", "Docker, Kubernetes, Azure" },
                    { 5, "654 Beach St, Miami, USA", "Miami, USA", new DateTime(1995, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "charlie.davis@example.com", null, null, "Single", "Charlie", 0, true, false, 3, "UI/UX Designer", null, "Davis", "777-888-9999", 1, new DateTime(2022, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miami, USA", "Figma, Adobe XD, Sketch" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_jobNature_EmployeeId",
                table: "Absences",
                column: "EmployeeId",
                principalTable: "jobNature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDrivingLicenses_jobNature_EmployeeId",
                table: "EmployeeDrivingLicenses",
                column: "EmployeeId",
                principalTable: "jobNature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_jobNature_Departments_DepartmentId",
                table: "jobNature",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_jobNature_JobNatures_JobNatureId",
                table: "jobNature",
                column: "JobNatureId",
                principalTable: "JobNatures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_jobNature_Projects_ProjectId",
                table: "jobNature",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_jobNature_EmployeeId",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDrivingLicenses_jobNature_EmployeeId",
                table: "EmployeeDrivingLicenses");

            migrationBuilder.DropForeignKey(
                name: "FK_jobNature_Departments_DepartmentId",
                table: "jobNature");

            migrationBuilder.DropForeignKey(
                name: "FK_jobNature_JobNatures_JobNatureId",
                table: "jobNature");

            migrationBuilder.DropForeignKey(
                name: "FK_jobNature_Projects_ProjectId",
                table: "jobNature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_jobNature",
                table: "jobNature");

            migrationBuilder.DeleteData(
                table: "jobNature",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "jobNature",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "jobNature",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "jobNature",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "jobNature",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JobNatures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobNatures",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobNatures",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "jobNature",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_jobNature_ProjectId",
                table: "Employees",
                newName: "IX_Employees_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_jobNature_JobNatureId",
                table: "Employees",
                newName: "IX_Employees_JobNatureId");

            migrationBuilder.RenameIndex(
                name: "IX_jobNature_DepartmentId",
                table: "Employees",
                newName: "IX_Employees_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Employees_EmployeeId",
                table: "Absences",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDrivingLicenses_Employees_EmployeeId",
                table: "EmployeeDrivingLicenses",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_JobNatures_JobNatureId",
                table: "Employees",
                column: "JobNatureId",
                principalTable: "JobNatures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Projects_ProjectId",
                table: "Employees",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
