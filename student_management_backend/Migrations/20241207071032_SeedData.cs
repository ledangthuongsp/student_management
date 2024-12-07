using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace student_management_backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_classes_ClassId",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_schedule_subjects",
                table: "schedule_subjects");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "users",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "users",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "subjects",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_schedule_subjects",
                table: "schedule_subjects",
                columns: new[] { "SubjectId", "ScheduleId", "DayOfWeek" });

            migrationBuilder.InsertData(
                table: "school_years",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "EndSchoolYear", "StartSchoolYear" },
                values: new object[] { 1, new DateTime(2024, 12, 7, 7, 10, 30, 953, DateTimeKind.Utc).AddTicks(3003), null, "2026", "2023" });

            migrationBuilder.InsertData(
                table: "subjects",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Title" },
                values: new object[] { 1, new DateTime(2024, 12, 7, 7, 10, 30, 953, DateTimeKind.Utc).AddTicks(3351), null, null, "Toán" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "AvatarUrl", "ClassId", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FullName", "Gender", "Password", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2024, 12, 7, 7, 10, 30, 953, DateTimeKind.Utc).AddTicks(3412), new DateTime(2024, 12, 7, 7, 10, 30, 953, DateTimeKind.Utc).AddTicks(3415), null, "principal@school.com", "Trinh Dinh A", 0, "$2a$11$A.JHHTDI3uuSe6uFo/1mL.lMUmsKN/QmJsMYRhjn2Mhnuf10vbKAi", "0000000001", 2 },
                    { 3, null, null, new DateTime(2024, 12, 7, 7, 10, 31, 279, DateTimeKind.Utc).AddTicks(1940), new DateTime(2024, 12, 7, 7, 10, 31, 279, DateTimeKind.Utc).AddTicks(1948), null, "teacher.002@school.com", "Tran Thi C", 0, "$2a$11$STKsMobYZ5aMhPPjWClu2.P1e4V5OU5eTQLRT4hBLbX6wMU6Vyt02", "0000000003", 1 }
                });

            migrationBuilder.InsertData(
                table: "classes",
                columns: new[] { "Id", "ClassName", "CreatedDate", "DeletedDate", "Grade", "SchoolYearId" },
                values: new object[] { 1, "A4", new DateTime(2024, 12, 7, 7, 10, 30, 953, DateTimeKind.Utc).AddTicks(3285), null, 10, 1 });

            migrationBuilder.InsertData(
                table: "schedules",
                columns: new[] { "Id", "ClassId", "CreatedDate", "DeletedDate", "SchoolYearId" },
                values: new object[] { 1, 1, new DateTime(2024, 12, 7, 7, 10, 30, 953, DateTimeKind.Utc).AddTicks(3319), null, 1 });

            migrationBuilder.InsertData(
                table: "teach_classes",
                columns: new[] { "ClassId", "TeacherId", "CreatedDate", "DeletedDate", "Id" },
                values: new object[] { 1, 3, new DateTime(2024, 12, 7, 7, 10, 31, 668, DateTimeKind.Utc).AddTicks(2135), null, 1 });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "AvatarUrl", "ClassId", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FullName", "Gender", "Password", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 2, null, 1, new DateTime(2024, 12, 7, 7, 10, 31, 124, DateTimeKind.Utc).AddTicks(8389), new DateTime(2024, 12, 7, 7, 10, 31, 124, DateTimeKind.Utc).AddTicks(8395), null, "teacher.001@school.com", "Nguyen Van B", 0, "$2a$11$UmA2oG698KWscNALy37i6ez56U5grTqtmHA2Ihk02xEOB12s2p4U2", "0000000002", 1 },
                    { 4, null, 1, new DateTime(2024, 12, 7, 7, 10, 31, 455, DateTimeKind.Utc).AddTicks(8615), new DateTime(2024, 12, 7, 7, 10, 31, 455, DateTimeKind.Utc).AddTicks(8623), null, "student.001@school.com", "Nguyen Duc D", 0, "$2a$11$h0I3/b2siuwLzV60JbAvQ.LELfpb.vXzgZAlbP5A6n4GJTu.hvH5S", "0000000004", 0 }
                });

            migrationBuilder.InsertData(
                table: "schedule_subjects",
                columns: new[] { "DayOfWeek", "ScheduleId", "SubjectId", "CreatedDate", "DeletedDate", "EndPeriod", "Id", "StartPeriod" },
                values: new object[] { 1, 1, 1, new DateTime(2024, 12, 7, 7, 10, 30, 953, DateTimeKind.Utc).AddTicks(3382), null, 3, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_PhoneNumber",
                table: "users",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_users_classes_ClassId",
                table: "users",
                column: "ClassId",
                principalTable: "classes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_classes_ClassId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_Email",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_PhoneNumber",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_schedule_subjects",
                table: "schedule_subjects");

            migrationBuilder.DeleteData(
                table: "schedule_subjects",
                keyColumns: new[] { "DayOfWeek", "ScheduleId", "SubjectId" },
                keyValues: new object[] { 1, 1, 1 });

            migrationBuilder.DeleteData(
                table: "teach_classes",
                keyColumns: new[] { "ClassId", "TeacherId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "schedules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "classes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "school_years",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "subjects",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_schedule_subjects",
                table: "schedule_subjects",
                columns: new[] { "SubjectId", "ScheduleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_users_classes_ClassId",
                table: "users",
                column: "ClassId",
                principalTable: "classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
