using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student_management_backend.Migrations
{
    /// <inheritdoc />
    public partial class AdjustSchoolYearType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("UPDATE \"school_years\" SET \"StartSchoolYear\" = 0 WHERE \"StartSchoolYear\" IS NULL OR \"StartSchoolYear\" !~ '^[0-9]+$';");
            migrationBuilder.Sql("ALTER TABLE \"school_years\" ALTER COLUMN \"StartSchoolYear\" TYPE integer USING \"StartSchoolYear\"::integer;");

            migrationBuilder.Sql("UPDATE \"school_years\" SET \"EndSchoolYear\" = 0 WHERE \"EndSchoolYear\" IS NULL OR \"EndSchoolYear\" !~ '^[0-9]+$';");
            migrationBuilder.Sql("ALTER TABLE \"school_years\" ALTER COLUMN \"EndSchoolYear\" TYPE integer USING \"EndSchoolYear\"::integer;");

            migrationBuilder.AlterColumn<int>(
                name: "StartSchoolYear",
                table: "school_years",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "EndSchoolYear",
                table: "school_years",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "classes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 2, 5, 28, 15, 884, DateTimeKind.Utc).AddTicks(8509));

            migrationBuilder.UpdateData(
                table: "schedule_subjects",
                keyColumns: new[] { "DayOfWeek", "ScheduleId", "SubjectId" },
                keyValues: new object[] { 1, 1, 1 },
                column: "CreatedDate",
                value: new DateTime(2025, 1, 2, 5, 28, 15, 884, DateTimeKind.Utc).AddTicks(8642));

            migrationBuilder.UpdateData(
                table: "schedules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 2, 5, 28, 15, 884, DateTimeKind.Utc).AddTicks(8586));

            migrationBuilder.UpdateData(
                table: "school_years",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndSchoolYear", "StartSchoolYear" },
                values: new object[] { new DateTime(2025, 1, 2, 5, 28, 15, 884, DateTimeKind.Utc).AddTicks(8249), 2026, 2023 });

            migrationBuilder.UpdateData(
                table: "subjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 2, 5, 28, 15, 884, DateTimeKind.Utc).AddTicks(8613));

            migrationBuilder.UpdateData(
                table: "teach_classes",
                keyColumns: new[] { "ClassId", "TeacherId" },
                keyValues: new object[] { 1, 3 },
                column: "CreatedDate",
                value: new DateTime(2025, 1, 2, 5, 28, 16, 423, DateTimeKind.Utc).AddTicks(6612));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2025, 1, 2, 5, 28, 15, 884, DateTimeKind.Utc).AddTicks(8667), new DateTime(2025, 1, 2, 5, 28, 15, 884, DateTimeKind.Utc).AddTicks(8670), "$2a$11$jT4BAiOw/m5cbrUIVK87aunwAyEXI2dWq.3LOwFv8gF44O/PY4Fi2" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2025, 1, 2, 5, 28, 16, 17, DateTimeKind.Utc).AddTicks(9935), new DateTime(2025, 1, 2, 5, 28, 16, 17, DateTimeKind.Utc).AddTicks(9941), "$2a$11$Vo2Bow9AiNoH2k9cOP.ise7OBgCRytdtc7OiQIij5BXH2328Ygn4a" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2025, 1, 2, 5, 28, 16, 157, DateTimeKind.Utc).AddTicks(3813), new DateTime(2025, 1, 2, 5, 28, 16, 157, DateTimeKind.Utc).AddTicks(3820), "$2a$11$kOMwKlAHw.PBhT0ZH.cIw.yBOKXPFKar8HNO6AdRSigENG6iKD0dW" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2025, 1, 2, 5, 28, 16, 290, DateTimeKind.Utc).AddTicks(3093), new DateTime(2025, 1, 2, 5, 28, 16, 290, DateTimeKind.Utc).AddTicks(3099), "$2a$11$67BPZqSGc6JBJS6FyM7qSOKpUKADfyZPBRvtmnLOw57qTKekIWYJ." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StartSchoolYear",
                table: "school_years",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "EndSchoolYear",
                table: "school_years",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "classes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 28, 20, 22, 51, 315, DateTimeKind.Utc).AddTicks(4565));

            migrationBuilder.UpdateData(
                table: "schedule_subjects",
                keyColumns: new[] { "DayOfWeek", "ScheduleId", "SubjectId" },
                keyValues: new object[] { 1, 1, 1 },
                column: "CreatedDate",
                value: new DateTime(2024, 12, 28, 20, 22, 51, 315, DateTimeKind.Utc).AddTicks(4629));

            migrationBuilder.UpdateData(
                table: "schedules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 28, 20, 22, 51, 315, DateTimeKind.Utc).AddTicks(4586));

            migrationBuilder.UpdateData(
                table: "school_years",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndSchoolYear", "StartSchoolYear" },
                values: new object[] { new DateTime(2024, 12, 28, 20, 22, 51, 315, DateTimeKind.Utc).AddTicks(4373), "2026", "2023" });

            migrationBuilder.UpdateData(
                table: "subjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 28, 20, 22, 51, 315, DateTimeKind.Utc).AddTicks(4607));

            migrationBuilder.UpdateData(
                table: "teach_classes",
                keyColumns: new[] { "ClassId", "TeacherId" },
                keyValues: new object[] { 1, 3 },
                column: "CreatedDate",
                value: new DateTime(2024, 12, 28, 20, 22, 51, 835, DateTimeKind.Utc).AddTicks(1381));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2024, 12, 28, 20, 22, 51, 315, DateTimeKind.Utc).AddTicks(4651), new DateTime(2024, 12, 28, 20, 22, 51, 315, DateTimeKind.Utc).AddTicks(4653), "$2a$11$JCZZKh38f5kdULdpVnQ/R.PvAaZJmfLR4ZvHXZoPnrlKftQZlzBDC" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2024, 12, 28, 20, 22, 51, 446, DateTimeKind.Utc).AddTicks(9173), new DateTime(2024, 12, 28, 20, 22, 51, 446, DateTimeKind.Utc).AddTicks(9178), "$2a$11$gqACY35qbdlj.FVMTAnxEu5dY2GIFrC9OKv3bMAaRRp9DP6pO2heK" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2024, 12, 28, 20, 22, 51, 579, DateTimeKind.Utc).AddTicks(2688), new DateTime(2024, 12, 28, 20, 22, 51, 579, DateTimeKind.Utc).AddTicks(2694), "$2a$11$qLGGUMxVj/A7W.FxAstkdutpR92YAD9yz2.7Ua9HfEJ/M7ZBuKnVe" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2024, 12, 28, 20, 22, 51, 708, DateTimeKind.Utc).AddTicks(2321), new DateTime(2024, 12, 28, 20, 22, 51, 708, DateTimeKind.Utc).AddTicks(2326), "$2a$11$Cx8e60TeY.g5c6BBu5T/FOc6KDI0iaqWS2ZnqZ7FRi./pnSZ7metC" });
        }
    }
}
