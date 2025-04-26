using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EEMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addCondidteAndOpenedJobTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Openedjobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Openedjobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Openedjobs_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Condidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Training = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FamilySituation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EssentialTraining = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguagesSpoken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<int>(type: "int", nullable: true),
                    Residence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    HasDrivingLicence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KnowMicrosoftOfficeSoftware = table.Column<bool>(type: "bit", nullable: false),
                    FatherFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherJob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherJob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfBrothersAndSisters = table.Column<int>(type: "int", nullable: false),
                    HusbandFullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HusbandJob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialSecurityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCardNumberReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClearedFromNationalService = table.Column<bool>(type: "bit", nullable: false),
                    NationalServiceDateSuspendedFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NationalServiceDateSuspendedTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NationalServiceSuitableNotIncorporated = table.Column<bool>(type: "bit", nullable: false),
                    OpenedJobId = table.Column<int>(type: "int", nullable: true),
                    JobNatureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condidates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Condidates_JobNatures_JobNatureId",
                        column: x => x.JobNatureId,
                        principalTable: "JobNatures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Condidates_Openedjobs_OpenedJobId",
                        column: x => x.OpenedJobId,
                        principalTable: "Openedjobs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Condidates_JobNatureId",
                table: "Condidates",
                column: "JobNatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Condidates_OpenedJobId",
                table: "Condidates",
                column: "OpenedJobId");

            migrationBuilder.CreateIndex(
                name: "IX_Openedjobs_DepartmentId",
                table: "Openedjobs",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Condidates");

            migrationBuilder.DropTable(
                name: "Openedjobs");
        }
    }
}
