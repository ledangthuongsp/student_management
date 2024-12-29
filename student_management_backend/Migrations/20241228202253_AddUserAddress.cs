using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student_management_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "users",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "reviews",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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
                column: "CreatedDate",
                value: new DateTime(2024, 12, 28, 20, 22, 51, 315, DateTimeKind.Utc).AddTicks(4373));

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
                columns: new[] { "Address", "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { null, new DateTime(2024, 12, 28, 20, 22, 51, 315, DateTimeKind.Utc).AddTicks(4651), new DateTime(2024, 12, 28, 20, 22, 51, 315, DateTimeKind.Utc).AddTicks(4653), "$2a$11$JCZZKh38f5kdULdpVnQ/R.PvAaZJmfLR4ZvHXZoPnrlKftQZlzBDC" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { null, new DateTime(2024, 12, 28, 20, 22, 51, 446, DateTimeKind.Utc).AddTicks(9173), new DateTime(2024, 12, 28, 20, 22, 51, 446, DateTimeKind.Utc).AddTicks(9178), "$2a$11$gqACY35qbdlj.FVMTAnxEu5dY2GIFrC9OKv3bMAaRRp9DP6pO2heK" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { null, new DateTime(2024, 12, 28, 20, 22, 51, 579, DateTimeKind.Utc).AddTicks(2688), new DateTime(2024, 12, 28, 20, 22, 51, 579, DateTimeKind.Utc).AddTicks(2694), "$2a$11$qLGGUMxVj/A7W.FxAstkdutpR92YAD9yz2.7Ua9HfEJ/M7ZBuKnVe" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { null, new DateTime(2024, 12, 28, 20, 22, 51, 708, DateTimeKind.Utc).AddTicks(2321), new DateTime(2024, 12, 28, 20, 22, 51, 708, DateTimeKind.Utc).AddTicks(2326), "$2a$11$Cx8e60TeY.g5c6BBu5T/FOc6KDI0iaqWS2ZnqZ7FRi./pnSZ7metC" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "users");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "users",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "reviews",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "classes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 7, 7, 10, 30, 953, DateTimeKind.Utc).AddTicks(3285));

            migrationBuilder.UpdateData(
                table: "schedule_subjects",
                keyColumns: new[] { "DayOfWeek", "ScheduleId", "SubjectId" },
                keyValues: new object[] { 1, 1, 1 },
                column: "CreatedDate",
                value: new DateTime(2024, 12, 7, 7, 10, 30, 953, DateTimeKind.Utc).AddTicks(3382));

            migrationBuilder.UpdateData(
                table: "schedules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 7, 7, 10, 30, 953, DateTimeKind.Utc).AddTicks(3319));

            migrationBuilder.UpdateData(
                table: "school_years",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 7, 7, 10, 30, 953, DateTimeKind.Utc).AddTicks(3003));

            migrationBuilder.UpdateData(
                table: "subjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 7, 7, 10, 30, 953, DateTimeKind.Utc).AddTicks(3351));

            migrationBuilder.UpdateData(
                table: "teach_classes",
                keyColumns: new[] { "ClassId", "TeacherId" },
                keyValues: new object[] { 1, 3 },
                column: "CreatedDate",
                value: new DateTime(2024, 12, 7, 7, 10, 31, 668, DateTimeKind.Utc).AddTicks(2135));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2024, 12, 7, 7, 10, 30, 953, DateTimeKind.Utc).AddTicks(3412), new DateTime(2024, 12, 7, 7, 10, 30, 953, DateTimeKind.Utc).AddTicks(3415), "$2a$11$A.JHHTDI3uuSe6uFo/1mL.lMUmsKN/QmJsMYRhjn2Mhnuf10vbKAi" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2024, 12, 7, 7, 10, 31, 124, DateTimeKind.Utc).AddTicks(8389), new DateTime(2024, 12, 7, 7, 10, 31, 124, DateTimeKind.Utc).AddTicks(8395), "$2a$11$UmA2oG698KWscNALy37i6ez56U5grTqtmHA2Ihk02xEOB12s2p4U2" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2024, 12, 7, 7, 10, 31, 279, DateTimeKind.Utc).AddTicks(1940), new DateTime(2024, 12, 7, 7, 10, 31, 279, DateTimeKind.Utc).AddTicks(1948), "$2a$11$STKsMobYZ5aMhPPjWClu2.P1e4V5OU5eTQLRT4hBLbX6wMU6Vyt02" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "DateOfBirth", "Password" },
                values: new object[] { new DateTime(2024, 12, 7, 7, 10, 31, 455, DateTimeKind.Utc).AddTicks(8615), new DateTime(2024, 12, 7, 7, 10, 31, 455, DateTimeKind.Utc).AddTicks(8623), "$2a$11$h0I3/b2siuwLzV60JbAvQ.LELfpb.vXzgZAlbP5A6n4GJTu.hvH5S" });
        }
    }
}
