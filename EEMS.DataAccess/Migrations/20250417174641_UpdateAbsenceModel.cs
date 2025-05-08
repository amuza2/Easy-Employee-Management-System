using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EEMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAbsenceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_AbsenceTypes_AbsenceTypeId",
                table: "Absences");

            migrationBuilder.DropColumn(
                name: "Days",
                table: "Absences");

            migrationBuilder.AlterColumn<int>(
                name: "AbsenceTypeId",
                table: "Absences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "HasJustification",
                table: "Absences",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                column: "Gender",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                column: "Gender",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_AbsenceTypes_AbsenceTypeId",
                table: "Absences",
                column: "AbsenceTypeId",
                principalTable: "AbsenceTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_AbsenceTypes_AbsenceTypeId",
                table: "Absences");

            migrationBuilder.DropColumn(
                name: "HasJustification",
                table: "Absences");

            migrationBuilder.AlterColumn<int>(
                name: "AbsenceTypeId",
                table: "Absences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Days",
                table: "Absences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                column: "Gender",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                column: "Gender",
                value: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_AbsenceTypes_AbsenceTypeId",
                table: "Absences",
                column: "AbsenceTypeId",
                principalTable: "AbsenceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
