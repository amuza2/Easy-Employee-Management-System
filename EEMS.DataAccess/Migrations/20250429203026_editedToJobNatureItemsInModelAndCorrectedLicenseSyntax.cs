using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EEMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class editedToJobNatureItemsInModelAndCorrectedLicenseSyntax : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HasDrivingLicence",
                table: "Condidates",
                newName: "JobNatureItem");

            migrationBuilder.AddColumn<string>(
                name: "JobNatureItem",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HasDrivingLicense",
                table: "Condidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Condidates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HasDrivingLicense", "JobNatureId", "JobNatureItem" },
                values: new object[] { "Have", null, "FullTime" });

            migrationBuilder.UpdateData(
                table: "Condidates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HasDrivingLicense", "InterviewDate", "JobNatureId", "JobNatureItem" },
                values: new object[] { "NotHave", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Local), null, "FullTime" });

            migrationBuilder.UpdateData(
                table: "Condidates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HasDrivingLicense", "InterviewDate", "JobNatureId", "JobNatureItem" },
                values: new object[] { "Have", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Local), null, "FullTime" });

            migrationBuilder.UpdateData(
                table: "Condidates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HasDrivingLicense", "InterviewDate", "JobNatureId", "JobNatureItem" },
                values: new object[] { "NotHave", new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Local), null, "FullTime" });

            migrationBuilder.UpdateData(
                table: "Condidates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "HasDrivingLicense", "InterviewDate", "JobNatureId", "JobNatureItem" },
                values: new object[] { "Have", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Local), null, "FullTime" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "JobNatureId", "JobNatureItem" },
                values: new object[] { null, "FullTime" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "JobNatureId", "JobNatureItem" },
                values: new object[] { null, "FullTime" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "JobNatureId", "JobNatureItem" },
                values: new object[] { null, "FullTime" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "JobNatureId", "JobNatureItem" },
                values: new object[] { null, "FullTime" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "JobNatureId", "JobNatureItem" },
                values: new object[] { null, "FullTime" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "JobNatureId", "JobNatureItem" },
                values: new object[] { null, "FullTime" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "JobNatureId", "JobNatureItem" },
                values: new object[] { null, "FullTime" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobNatureItem",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "HasDrivingLicense",
                table: "Condidates");

            migrationBuilder.RenameColumn(
                name: "JobNatureItem",
                table: "Condidates",
                newName: "HasDrivingLicence");

            migrationBuilder.UpdateData(
                table: "Condidates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HasDrivingLicence", "JobNatureId" },
                values: new object[] { "Have", 1 });

            migrationBuilder.UpdateData(
                table: "Condidates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HasDrivingLicence", "InterviewDate", "JobNatureId" },
                values: new object[] { "NotHave", new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Local), 2 });

            migrationBuilder.UpdateData(
                table: "Condidates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HasDrivingLicence", "InterviewDate", "JobNatureId" },
                values: new object[] { "Have", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Local), 3 });

            migrationBuilder.UpdateData(
                table: "Condidates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HasDrivingLicence", "InterviewDate", "JobNatureId" },
                values: new object[] { "NotHave", new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Local), 2 });

            migrationBuilder.UpdateData(
                table: "Condidates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "HasDrivingLicence", "InterviewDate", "JobNatureId" },
                values: new object[] { "Have", new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Local), 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "JobNatureId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "JobNatureId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "JobNatureId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                column: "JobNatureId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                column: "JobNatureId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6,
                column: "JobNatureId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7,
                column: "JobNatureId",
                value: 3);
        }
    }
}
