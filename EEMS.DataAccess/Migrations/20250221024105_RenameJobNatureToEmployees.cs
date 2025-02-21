using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EEMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameJobNatureToEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
