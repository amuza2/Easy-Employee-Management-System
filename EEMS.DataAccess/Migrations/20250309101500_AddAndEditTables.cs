using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EEMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddAndEditTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Projects_ProjectId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ProjectId",
                table: "Employees");

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

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Employees",
                newName: "LeaveId");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeaveDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sanctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Panishement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateHappened = table.Column<DateOnly>(type: "date", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sanctions_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Length = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vacations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diplomas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateIssued = table.Column<DateOnly>(type: "date", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diplomas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diplomas_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diplomas_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesTraining",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesTraining", x => new { x.EmployeeId, x.TrainingId });
                    table.ForeignKey(
                        name: "FK_EmployeesTraining_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeesTraining_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LeaveId",
                table: "Employees",
                column: "LeaveId",
                unique: true,
                filter: "[LeaveId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Diplomas_EmployeeId",
                table: "Diplomas",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Diplomas_TrainingId",
                table: "Diplomas",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesTraining_TrainingId",
                table: "EmployeesTraining",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Sanctions_EmployeeId",
                table: "Sanctions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_EmployeeId",
                table: "Vacations",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Leaves_LeaveId",
                table: "Employees",
                column: "LeaveId",
                principalTable: "Leaves",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Leaves_LeaveId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Diplomas");

            migrationBuilder.DropTable(
                name: "EmployeesTraining");

            migrationBuilder.DropTable(
                name: "Leaves");

            migrationBuilder.DropTable(
                name: "Sanctions");

            migrationBuilder.DropTable(
                name: "Vacations");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Employees_LeaveId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "LeaveId",
                table: "Employees",
                newName: "ProjectId");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

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
                table: "Employees",
                columns: new[] { "Id", "Address", "BirthLocation", "DateOfBirth", "DepartmentId", "Email", "EssentialTraining", "Experience", "FamilySituation", "FirstName", "Gender", "IsActive", "IsDeleted", "JobNatureId", "JobTitle", "LanguagesSpoken", "LastName", "Phone", "ProjectId", "RecruitmentDate", "Residence", "Training" },
                values: new object[,]
                {
                    { 1, "123 Main St, New York, USA", "New York, USA", new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "john.doe@example.com", null, null, "Single", "John", 0, true, false, 1, "Software Engineer", null, "Doe", "123-456-7890", 1, new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "New York, USA", "C#, .NET, SQL" },
                    { 2, "456 Elm St, Los Angeles, USA", "Los Angeles, USA", new DateTime(1985, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "jane.smith@example.com", null, null, "Married", "Jane", 1, true, false, 2, "Project Manager", null, "Smith", "987-654-3210", 2, new DateTime(2018, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Los Angeles, USA", "PMP, Agile, Scrum" },
                    { 3, "789 Oak St, Chicago, USA", "Chicago, USA", new DateTime(1992, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "alice.johnson@example.com", null, null, "Single", "Alice", 1, true, false, 3, "QA Engineer", null, "Johnson", "555-123-4567", 1, new DateTime(2021, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago, USA", "Selenium, Manual Testing" },
                    { 4, "321 Pine St, Houston, USA", "Houston, USA", new DateTime(1988, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "bob.brown@example.com", null, null, "Married", "Bob", 0, true, false, 1, "DevOps Engineer", null, "Brown", "444-555-6666", 3, new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Houston, USA", "Docker, Kubernetes, Azure" },
                    { 5, "654 Beach St, Miami, USA", "Miami, USA", new DateTime(1995, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "charlie.davis@example.com", null, null, "Single", "Charlie", 0, true, false, 3, "UI/UX Designer", null, "Davis", "777-888-9999", 1, new DateTime(2022, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miami, USA", "Figma, Adobe XD, Sketch" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProjectId",
                table: "Employees",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Projects_ProjectId",
                table: "Employees",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
