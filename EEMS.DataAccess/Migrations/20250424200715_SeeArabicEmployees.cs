using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EEMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeeArabicEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "BirthLocation", "DateOfBirth", "Email", "EssentialTraining", "Experience", "FirstName", "JobTitle", "LanguagesSpoken", "LastName", "Phone", "RecruitmentDate", "Residence", "Training" },
                values: new object[] { "شارع الملك عبدالعزيز، الرياض", "الرياض", new DateTime(1995, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmad@example.com", "ASP.NET Core", 3, "أحمد", "مهندس برمجيات", "العربية، الإنجليزية", "الزيدي", "0599988776", new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "الرياض", "تدريب في تطوير الويب" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "BirthLocation", "DateOfBirth", "Email", "EssentialTraining", "Experience", "FirstName", "IsActive", "JobTitle", "LanguagesSpoken", "LastName", "Phone", "RecruitmentDate", "Residence", "Training" },
                values: new object[] { "حي الشاطئ، جدة", "جدة", new DateTime(1992, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara@example.com", "UML، تحليل البيانات", 5, "سارة", "Active", "محللة نظم", "العربية", "العتيبي", "0501122334", new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "جدة", "تحليل نظم المعلومات" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "BirthLocation", "DateOfBirth", "DepartmentId", "Email", "EssentialTraining", "Experience", "FamilySituation", "FirstName", "Gender", "IsActive", "JobNatureId", "JobTitle", "LanguagesSpoken", "LastName", "Phone", "RecruitmentDate", "Residence", "Training" },
                values: new object[] { "حي الفيصلية، الدمام", "الدمام", new DateTime(1988, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "khaled.anazi@example.com", "إدارة فرق العمل، PMP", 10, "Married", "خالد", "Male", "Active", 1, "مدير مشاريع", "العربية، الإنجليزية", "العنزي", "0567788990", new DateTime(2020, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "الدمام", "إدارة المشاريع الاحترافية (PMP)" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "BirthLocation", "DateOfBirth", "Email", "EssentialTraining", "Experience", "FamilySituation", "FirstName", "JobNatureId", "JobTitle", "LanguagesSpoken", "LastName", "Phone", "RecruitmentDate", "Residence", "Training" },
                values: new object[] { "حي العزيزية، مكة", "مكة", new DateTime(1996, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "nada.harbi@example.com", "Adobe Photoshop، Figma", 2, "Single", "ندى", 2, "مصممة جرافيك", "العربية، الإنجليزية", "الحربي", "0553344556", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مكة", "دورات Adobe و UI/UX" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "BirthLocation", "DateOfBirth", "Email", "EssentialTraining", "Experience", "FirstName", "Gender", "IsActive", "JobNatureId", "JobTitle", "LanguagesSpoken", "LastName", "Phone", "RecruitmentDate", "Residence", "Training" },
                values: new object[] { "حي المنسك، أبها", "أبها", new DateTime(1990, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "fahad.shahri@example.com", "أمن الشبكات", 8, "فهد", "Male", "Inactive", 1, "أخصائي شبكات", "العربية", "الشهري", "0531122334", new DateTime(2019, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "أبها", "CCNA، أمن الشبكات" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "BirthLocation", "DateOfBirth", "DepartmentId", "Email", "EssentialTraining", "Experience", "FamilySituation", "FirstName", "Gender", "IsActive", "IsArchived", "JobNatureId", "JobTitle", "LanguagesSpoken", "LastName", "Phone", "RecruitmentDate", "Residence", "Training" },
                values: new object[,]
                {
                    { 6, "حي اليرموك، الخبر", "الخبر", new DateTime(1994, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "reem.subaie@example.com", "تخطيط الموارد، تقييم الأداء", 4, "Divorced", "ريم", "Female", "Active", false, 1, "أخصائية موارد بشرية", "العربية، الإنجليزية", "السبيعي", "0504455667", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "الخبر", "إدارة الموارد البشرية، تقييم الأداء" },
                    { 7, "حي النهضة، نجران", "نجران", new DateTime(1985, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "mazen.yami@example.com", "تدقيق مالي", 12, "Widowed", "مازن", "Male", "Active", false, 3, "محاسب", "العربية", "اليامي", "0542211334", new DateTime(2018, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "نجران", "معايير IFRS، تدقيق داخلي" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "BirthLocation", "DateOfBirth", "Email", "EssentialTraining", "Experience", "FirstName", "JobTitle", "LanguagesSpoken", "LastName", "Phone", "RecruitmentDate", "Residence", "Training" },
                values: new object[] { "123 Main St, New York, USA", "New York, USA", new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", null, null, "John", "Software Engineer", null, "Doe", "123-456-7890", new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "New York, USA", "C#, .NET, SQL" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "BirthLocation", "DateOfBirth", "Email", "EssentialTraining", "Experience", "FirstName", "IsActive", "JobTitle", "LanguagesSpoken", "LastName", "Phone", "RecruitmentDate", "Residence", "Training" },
                values: new object[] { "456 Elm St, Los Angeles, USA", "Los Angeles, USA", new DateTime(1985, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", null, null, "Jane", "Inactive", "Project Manager", null, "Smith", "987-654-3210", new DateTime(2018, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Los Angeles, USA", "PMP, Agile, Scrum" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "BirthLocation", "DateOfBirth", "DepartmentId", "Email", "EssentialTraining", "Experience", "FamilySituation", "FirstName", "Gender", "IsActive", "JobNatureId", "JobTitle", "LanguagesSpoken", "LastName", "Phone", "RecruitmentDate", "Residence", "Training" },
                values: new object[] { "789 Oak St, Chicago, USA", "Chicago, USA", new DateTime(1992, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "alice.johnson@example.com", null, null, "Single", "Alice", "Female", "Inactive", 3, "QA Engineer", null, "Johnson", "555-123-4567", new DateTime(2021, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago, USA", "Selenium, Manual Testing" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "BirthLocation", "DateOfBirth", "Email", "EssentialTraining", "Experience", "FamilySituation", "FirstName", "JobNatureId", "JobTitle", "LanguagesSpoken", "LastName", "Phone", "RecruitmentDate", "Residence", "Training" },
                values: new object[] { "321 Pine St, Houston, USA", "Houston, USA", new DateTime(1988, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.brown@example.com", null, null, "Married", "Bob", 1, "DevOps Engineer", null, "Brown", "444-555-6666", new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Houston, USA", "Docker, Kubernetes, Azure" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "BirthLocation", "DateOfBirth", "Email", "EssentialTraining", "Experience", "FirstName", "Gender", "IsActive", "JobNatureId", "JobTitle", "LanguagesSpoken", "LastName", "Phone", "RecruitmentDate", "Residence", "Training" },
                values: new object[] { "654 Beach St, Miami, USA", "Miami, USA", new DateTime(1995, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "charlie.davis@example.com", null, null, "Charlie", "Female", "Active", 3, "UI/UX Designer", null, "Davis", "777-888-9999", new DateTime(2022, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miami, USA", "Figma, Adobe XD, Sketch" });
        }
    }
}
