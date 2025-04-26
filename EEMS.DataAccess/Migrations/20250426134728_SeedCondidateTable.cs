using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EEMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedCondidateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Condidates",
                columns: new[] { "Id", "Address", "BankAccountNumber", "BirthLocation", "BloodGroup", "ClearedFromNationalService", "DateOfBirth", "Email", "EssentialTraining", "Experience", "FamilySituation", "FatherFullName", "FatherJob", "FirstName", "Gender", "HasDrivingLicence", "HusbandFullname", "HusbandJob", "InterviewDate", "IsArchived", "JobNatureId", "KnowMicrosoftOfficeSoftware", "LanguagesSpoken", "LastName", "MotherFullName", "MotherJob", "NationalCardNumber", "NationalCardNumberReleaseDate", "NationalServiceDateSuspendedFrom", "NationalServiceDateSuspendedTo", "NationalServiceSuitableNotIncorporated", "NumberOfBrothersAndSisters", "OpenedJobId", "Phone", "Residence", "SocialSecurityNumber", "Training" },
                values: new object[,]
                {
                    { 1, "وسط الجزائر العاصمة", "1234567890123456", "الجزائر العاصمة", "APlus", true, new DateTime(1995, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed.benali@example.com", "تطوير البرمجيات", 3, "Single", "محمد بن علي", "مهندس", "أحمد", "Male", "Have", null, null, new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, true, "العربية، الفرنسية، الإنجليزية", "بن علي", "فاطمة بوزيد", "معلمة", "123456789", new DateTime(2019, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 2, 1, "0550123456", "الجزائر العاصمة", "9876543210", "هندسة البرمجيات" },
                    { 2, "وسط مدينة وهران", "9876543210987654", "وهران", "BPlus", null, new DateTime(1998, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.boualem@example.com", "إدارة المشاريع", 1, "Single", "عبد القادر بوعلام", "طبيب", "سارة", "Female", "NotHave", null, null, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Local), false, 2, true, "العربية، الفرنسية", "بوعلام", "سميرة شريف", "ربة منزل", "987654321", new DateTime(2016, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 1, 2, "0550987654", "وهران", "1234567890", "إدارة الأعمال" },
                    { 3, "وسط مدينة قسنطينة", "1122334455667788", "قسنطينة", "OPlus", true, new DateTime(1993, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "mohamed.lamine@example.com", "صيانة المعدات الكهربائية", 5, "Married", "علي لمين", "محاسب", "محمد", "Male", "Have", null, null, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Local), false, 3, false, "العربية، الفرنسية", "لمين", "زهرة بلقاسم", "ممرضة", "112233445", new DateTime(2012, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 3, 1, "0770123456", "قسنطينة", "1122334455", "الهندسة الكهربائية" },
                    { 4, "حي 100 مسكن سطيف", "6677889900112233", "سطيف", "ABPlus", null, new DateTime(1996, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "khadija.yassine@example.com", "الإسعافات الأولية", 2, "Single", "عبد الله ياسين", "مقاول", "خديجة", "Female", "NotHave", null, null, new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Local), false, 2, true, "العربية، الفرنسية", "ياسين", "ليلى بوخديمي", "مدرسة", "556677889", new DateTime(2015, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 4, 3, "0660987654", "سطيف", "5566778899", "التمريض" },
                    { 5, "وسط مدينة عنابة", "4455667788990011", "عنابة", "BMinus", true, new DateTime(1990, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "abderrahmane.cherif@example.com", "ميكانيك السيارات", 7, "Married", "مصطفى شريف", "فني صيانة", "عبد الرحمن", "Male", "Have", null, null, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Local), false, 1, false, "العربية", "شريف", "نوال دحماني", "ربة منزل", "334455667", new DateTime(2010, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 5, 2, "0770887766", "عنابة", "3344556677", "الميكانيك" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Condidates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Condidates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Condidates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Condidates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Condidates",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
