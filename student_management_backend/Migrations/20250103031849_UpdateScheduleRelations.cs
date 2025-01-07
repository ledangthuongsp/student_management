using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student_management_backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateScheduleRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_schedules_ClassId",
                table: "schedules");

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "schedules",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "classes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 3, 3, 18, 48, 955, DateTimeKind.Utc).AddTicks(3166));

            migrationBuilder.UpdateData(
                table: "schedule_subjects",
                keyColumns: new[] { "DayOfWeek", "ScheduleId", "SubjectId" },
                keyValues: new object[] { 1, 1, 1 },
                column: "CreatedDate",
                value: new DateTime(2025, 1, 3, 3, 18, 48, 955, DateTimeKind.Utc).AddTicks(3263));

            migrationBuilder.UpdateData(
                table: "schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndApplyingDate", "Grade", "StartApplyingDate" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 18, 48, 955, DateTimeKind.Utc).AddTicks(3187), new DateTime(2026, 1, 3, 3, 18, 48, 955, DateTimeKind.Utc).AddTicks(3189), 10, new DateTime(2025, 1, 3, 3, 18, 48, 955, DateTimeKind.Utc).AddTicks(3189) });

            migrationBuilder.UpdateData(
                table: "school_years",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 3, 3, 18, 48, 955, DateTimeKind.Utc).AddTicks(2991));

            migrationBuilder.UpdateData(
                table: "subjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 3, 3, 18, 48, 955, DateTimeKind.Utc).AddTicks(3241));

            migrationBuilder.UpdateData(
                table: "teach_classes",
                keyColumns: new[] { "ClassId", "TeacherId" },
                keyValues: new object[] { 1, 3 },
                column: "CreatedDate",
                value: new DateTime(2025, 1, 3, 3, 18, 49, 503, DateTimeKind.Utc).AddTicks(1596));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 18, 48, 955, DateTimeKind.Utc).AddTicks(3287), new DateTime(2025, 1, 3, 3, 18, 48, 955, DateTimeKind.Utc).AddTicks(3290), "$2a$11$Q031AjbIEB3cWpyHZZzGr.qBdTJ3EJ83uIPgpwhsMFuOsuiFF35uO" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 18, 49, 91, DateTimeKind.Utc).AddTicks(3167), new DateTime(2025, 1, 3, 3, 18, 49, 91, DateTimeKind.Utc).AddTicks(3173), "$2a$11$x2a5iki0zbn0rduHPHZHwOB6wpLZr.HjuwaOAj7jjH0DTwF7FyZza" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 18, 49, 228, DateTimeKind.Utc).AddTicks(5662), new DateTime(2025, 1, 3, 3, 18, 49, 228, DateTimeKind.Utc).AddTicks(5668), "$2a$11$UaOpDme8TwXT67n2gjb7su1lANOy5o5Bx4l9Mwb2QhLe/0p9F9jhG" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2025, 1, 3, 3, 18, 49, 367, DateTimeKind.Utc).AddTicks(9231), new DateTime(2025, 1, 3, 3, 18, 49, 367, DateTimeKind.Utc).AddTicks(9236), "$2a$11$EIqU1/g2/tMSLH1xAdS88.VWn66r.p5t3fF/cT/cTMJn/VzNwz96y" });

            migrationBuilder.CreateIndex(
                name: "IX_schedules_ClassId",
                table: "schedules",
                column: "ClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_schedules_ClassId",
                table: "schedules");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "schedules");

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
                columns: new[] { "CreatedDate", "EndApplyingDate", "StartApplyingDate" },
                values: new object[] { new DateTime(2025, 1, 2, 18, 16, 38, 685, DateTimeKind.Utc).AddTicks(4838), new DateTime(2026, 1, 2, 18, 16, 38, 685, DateTimeKind.Utc).AddTicks(4840), new DateTime(2025, 1, 2, 18, 16, 38, 685, DateTimeKind.Utc).AddTicks(4840) });

            migrationBuilder.UpdateData(
                table: "school_years",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 2, 18, 16, 38, 685, DateTimeKind.Utc).AddTicks(4634));

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

            migrationBuilder.CreateIndex(
                name: "IX_schedules_ClassId",
                table: "schedules",
                column: "ClassId",
                unique: true);
        }
    }
}
