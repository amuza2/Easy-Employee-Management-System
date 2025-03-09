using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EEMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedingDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Employees",
                columns: new[] { "Id", "Address", "BirthLocation", "DateOfBirth", "DepartmentId", "Email", "EssentialTraining", "Experience", "FamilySituation", "FirstName", "Gender", "IsActive", "IsDeleted", "JobNatureId", "JobTitle", "LanguagesSpoken", "LastName", "LeaveId", "Phone", "RecruitmentDate", "Residence", "Training" },
                values: new object[,]
                {
                    { 1, "123 Main St, New York, USA", "New York, USA", new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "john.doe@example.com", null, null, "Single", "John", 0, true, false, 1, "Software Engineer", null, "Doe", null, "123-456-7890", new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "New York, USA", "C#, .NET, SQL" },
                    { 2, "456 Elm St, Los Angeles, USA", "Los Angeles, USA", new DateTime(1985, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "jane.smith@example.com", null, null, "Married", "Jane", 1, true, false, 2, "Project Manager", null, "Smith", null, "987-654-3210", new DateTime(2018, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Los Angeles, USA", "PMP, Agile, Scrum" },
                    { 3, "789 Oak St, Chicago, USA", "Chicago, USA", new DateTime(1992, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "alice.johnson@example.com", null, null, "Single", "Alice", 1, true, false, 3, "QA Engineer", null, "Johnson", null, "555-123-4567", new DateTime(2021, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago, USA", "Selenium, Manual Testing" },
                    { 4, "321 Pine St, Houston, USA", "Houston, USA", new DateTime(1988, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "bob.brown@example.com", null, null, "Married", "Bob", 0, true, false, 1, "DevOps Engineer", null, "Brown", null, "444-555-6666", new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Houston, USA", "Docker, Kubernetes, Azure" },
                    { 5, "654 Beach St, Miami, USA", "Miami, USA", new DateTime(1995, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "charlie.davis@example.com", null, null, "Single", "Charlie", 0, true, false, 3, "UI/UX Designer", null, "Davis", null, "777-888-9999", new DateTime(2022, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miami, USA", "Figma, Adobe XD, Sketch" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
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
        }
    }
}
