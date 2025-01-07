using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student_management_backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedules_school_years_SchoolYearId",
                table: "schedules");

            migrationBuilder.AlterColumn<int>(
                name: "SchoolYearId",
                table: "schedules",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndApplyingDate",
                table: "schedules",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartApplyingDate",
                table: "schedules",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "classes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 2, 18, 16, 38, 685, DateTimeKind.Utc).AddTicks(4815));

            migrationBuilder.UpdateData(
                table: "schedule_subjects",
                keyColumns: new[] { "DayOfWeek", "ScheduleId", "SubjectId" },
                keyValues: new object[] { 1, 1, 1 },
                column: "CreatedDate",
                value: new DateTime(2025, 1, 2, 18, 16, 38, 685, DateTimeKind.Utc).AddTicks(4885));

            migrationBuilder.UpdateData(
                table: "schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndApplyingDate", "SchoolYearId", "StartApplyingDate" },
                values: new object[] { new DateTime(2025, 1, 2, 18, 16, 38, 685, DateTimeKind.Utc).AddTicks(4838), new DateTime(2026, 1, 2, 18, 16, 38, 685, DateTimeKind.Utc).AddTicks(4840), null, new DateTime(2025, 1, 2, 18, 16, 38, 685, DateTimeKind.Utc).AddTicks(4840) });

            migrationBuilder.UpdateData(
                table: "school_years",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndSchoolYear", "StartSchoolYear" },
                values: new object[] { new DateTime(2025, 1, 2, 18, 16, 38, 685, DateTimeKind.Utc).AddTicks(4634), 2028, 2025 });

            migrationBuilder.UpdateData(
                table: "subjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 2, 18, 16, 38, 685, DateTimeKind.Utc).AddTicks(4861));

            migrationBuilder.UpdateData(
                table: "teach_classes",
                keyColumns: new[] { "ClassId", "TeacherId" },
                keyValues: new object[] { 1, 3 },
                column: "CreatedDate",
                value: new DateTime(2025, 1, 2, 18, 16, 39, 231, DateTimeKind.Utc).AddTicks(9578));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2025, 1, 2, 18, 16, 38, 685, DateTimeKind.Utc).AddTicks(4911), new DateTime(2025, 1, 2, 18, 16, 38, 685, DateTimeKind.Utc).AddTicks(4913), "$2a$11$ivmod7KeKbmQ20HHnctsYulT3RKvC0KsjpbwRnqrYYFMBw8aKQMSm" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2025, 1, 2, 18, 16, 38, 825, DateTimeKind.Utc).AddTicks(2448), new DateTime(2025, 1, 2, 18, 16, 38, 825, DateTimeKind.Utc).AddTicks(2454), "$2a$11$SBuhAR6QwQBCM9WrLcNzdO.wVafC/s00qPPzPuKHc7AeZ4xbxLKMi" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2025, 1, 2, 18, 16, 38, 959, DateTimeKind.Utc).AddTicks(8667), new DateTime(2025, 1, 2, 18, 16, 38, 959, DateTimeKind.Utc).AddTicks(8673), "$2a$11$YN08kRxc9gZefGHgFs68qOqjx99x8RwFUMwWI6LUgjocrPzqj8O5a" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2025, 1, 2, 18, 16, 39, 93, DateTimeKind.Utc).AddTicks(6), new DateTime(2025, 1, 2, 18, 16, 39, 93, DateTimeKind.Utc).AddTicks(11), "$2a$11$3LEZ0.mn/6tIteC2jPpcWeNitHlETy6nu4C87EyH3A.0OBAa6TKDu" });

            migrationBuilder.AddForeignKey(
                name: "FK_schedules_school_years_SchoolYearId",
                table: "schedules",
                column: "SchoolYearId",
                principalTable: "school_years",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedules_school_years_SchoolYearId",
                table: "schedules");

            migrationBuilder.DropColumn(
                name: "EndApplyingDate",
                table: "schedules");

            migrationBuilder.DropColumn(
                name: "StartApplyingDate",
                table: "schedules");

            migrationBuilder.AlterColumn<int>(
                name: "SchoolYearId",
                table: "schedules",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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
                columns: new[] { "CreatedDate", "SchoolYearId" },
                values: new object[] { new DateTime(2025, 1, 2, 5, 28, 15, 884, DateTimeKind.Utc).AddTicks(8586), 1 });

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

            migrationBuilder.AddForeignKey(
                name: "FK_schedules_school_years_SchoolYearId",
                table: "schedules",
                column: "SchoolYearId",
                principalTable: "school_years",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
