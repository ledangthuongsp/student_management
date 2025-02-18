﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace student_management_backend.Migrations
{
    [DbContext(typeof(NeonDbContext))]
    [Migration("20250102052818_AdjustSchoolYearType")]
    partial class AdjustSchoolYearType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("student_management_backend.Core.Models.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Grade")
                        .HasColumnType("integer");

                    b.Property<int>("Semester")
                        .HasColumnType("integer");

                    b.Property<int>("SubjectId")
                        .HasColumnType("integer");

                    b.Property<int>("TeacherId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("assignments", (string)null);
                });

            modelBuilder.Entity("student_management_backend.Core.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Grade")
                        .HasColumnType("integer");

                    b.Property<int>("SchoolYearId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SchoolYearId");

                    b.ToTable("classes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassName = "A4",
                            CreatedDate = new DateTime(2025, 1, 2, 5, 28, 15, 884, DateTimeKind.Utc).AddTicks(8509),
                            Grade = 10,
                            SchoolYearId = 1
                        });
                });

            modelBuilder.Entity("student_management_backend.Core.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Score")
                        .HasColumnType("double precision");

                    b.Property<int>("SubmitId")
                        .HasColumnType("integer");

                    b.Property<int>("TeacherId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubmitId")
                        .IsUnique();

                    b.HasIndex("TeacherId");

                    b.ToTable("reviews", (string)null);
                });

            modelBuilder.Entity("student_management_backend.Core.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("SchoolYearId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClassId")
                        .IsUnique();

                    b.HasIndex("SchoolYearId");

                    b.ToTable("schedules", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassId = 1,
                            CreatedDate = new DateTime(2025, 1, 2, 5, 28, 15, 884, DateTimeKind.Utc).AddTicks(8586),
                            SchoolYearId = 1
                        });
                });

            modelBuilder.Entity("student_management_backend.Core.Models.ScheduleSubject", b =>
                {
                    b.Property<int>("SubjectId")
                        .HasColumnType("integer");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("integer");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("EndPeriod")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("StartPeriod")
                        .HasColumnType("integer");

                    b.HasKey("SubjectId", "ScheduleId", "DayOfWeek");

                    b.HasIndex("ScheduleId");

                    b.ToTable("schedule_subjects", (string)null);

                    b.HasData(
                        new
                        {
                            SubjectId = 1,
                            ScheduleId = 1,
                            DayOfWeek = 1,
                            CreatedDate = new DateTime(2025, 1, 2, 5, 28, 15, 884, DateTimeKind.Utc).AddTicks(8642),
                            EndPeriod = 3,
                            Id = 1,
                            StartPeriod = 1
                        });
                });

            modelBuilder.Entity("student_management_backend.Core.Models.SchoolYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("EndSchoolYear")
                        .HasColumnType("integer");

                    b.Property<int>("StartSchoolYear")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("school_years", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2025, 1, 2, 5, 28, 15, 884, DateTimeKind.Utc).AddTicks(8249),
                            EndSchoolYear = 2026,
                            StartSchoolYear = 2023
                        });
                });

            modelBuilder.Entity("student_management_backend.Core.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("subjects", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2025, 1, 2, 5, 28, 15, 884, DateTimeKind.Utc).AddTicks(8613),
                            Title = "Toán"
                        });
                });

            modelBuilder.Entity("student_management_backend.Core.Models.Submit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AssignmentId")
                        .HasColumnType("integer");

                    b.Property<string>("AttachFile")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("StudentId");

                    b.ToTable("submits", (string)null);
                });

            modelBuilder.Entity("student_management_backend.Core.Models.TeachClass", b =>
                {
                    b.Property<int>("TeacherId")
                        .HasColumnType("integer");

                    b.Property<int>("ClassId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("TeacherId", "ClassId");

                    b.HasIndex("ClassId");

                    b.ToTable("teach_classes", (string)null);

                    b.HasData(
                        new
                        {
                            TeacherId = 3,
                            ClassId = 1,
                            CreatedDate = new DateTime(2025, 1, 2, 5, 28, 16, 423, DateTimeKind.Utc).AddTicks(6612),
                            Id = 1
                        });
                });

            modelBuilder.Entity("student_management_backend.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("text");

                    b.Property<int?>("ClassId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2025, 1, 2, 5, 28, 15, 884, DateTimeKind.Utc).AddTicks(8667),
                            DateOfBirth = new DateTime(2025, 1, 2, 5, 28, 15, 884, DateTimeKind.Utc).AddTicks(8670),
                            Email = "principal@school.com",
                            FullName = "Trinh Dinh A",
                            Gender = 0,
                            Password = "$2a$11$jT4BAiOw/m5cbrUIVK87aunwAyEXI2dWq.3LOwFv8gF44O/PY4Fi2",
                            PhoneNumber = "0000000001",
                            Role = 2
                        },
                        new
                        {
                            Id = 2,
                            ClassId = 1,
                            CreatedDate = new DateTime(2025, 1, 2, 5, 28, 16, 17, DateTimeKind.Utc).AddTicks(9935),
                            DateOfBirth = new DateTime(2025, 1, 2, 5, 28, 16, 17, DateTimeKind.Utc).AddTicks(9941),
                            Email = "teacher.001@school.com",
                            FullName = "Nguyen Van B",
                            Gender = 0,
                            Password = "$2a$11$Vo2Bow9AiNoH2k9cOP.ise7OBgCRytdtc7OiQIij5BXH2328Ygn4a",
                            PhoneNumber = "0000000002",
                            Role = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2025, 1, 2, 5, 28, 16, 157, DateTimeKind.Utc).AddTicks(3813),
                            DateOfBirth = new DateTime(2025, 1, 2, 5, 28, 16, 157, DateTimeKind.Utc).AddTicks(3820),
                            Email = "teacher.002@school.com",
                            FullName = "Tran Thi C",
                            Gender = 0,
                            Password = "$2a$11$kOMwKlAHw.PBhT0ZH.cIw.yBOKXPFKar8HNO6AdRSigENG6iKD0dW",
                            PhoneNumber = "0000000003",
                            Role = 1
                        },
                        new
                        {
                            Id = 4,
                            ClassId = 1,
                            CreatedDate = new DateTime(2025, 1, 2, 5, 28, 16, 290, DateTimeKind.Utc).AddTicks(3093),
                            DateOfBirth = new DateTime(2025, 1, 2, 5, 28, 16, 290, DateTimeKind.Utc).AddTicks(3099),
                            Email = "student.001@school.com",
                            FullName = "Nguyen Duc D",
                            Gender = 0,
                            Password = "$2a$11$67BPZqSGc6JBJS6FyM7qSOKpUKADfyZPBRvtmnLOw57qTKekIWYJ.",
                            PhoneNumber = "0000000004",
                            Role = 0
                        });
                });

            modelBuilder.Entity("student_management_backend.Core.Models.Assignment", b =>
                {
                    b.HasOne("student_management_backend.Core.Models.Class", "Class")
                        .WithMany("Assignments")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("student_management_backend.Core.Models.Subject", "Subject")
                        .WithMany("Assignments")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("student_management_backend.Core.Models.User", "User")
                        .WithMany("Assignments")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Subject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("student_management_backend.Core.Models.Class", b =>
                {
                    b.HasOne("student_management_backend.Core.Models.SchoolYear", "SchoolYear")
                        .WithMany("Classes")
                        .HasForeignKey("SchoolYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SchoolYear");
                });

            modelBuilder.Entity("student_management_backend.Core.Models.Review", b =>
                {
                    b.HasOne("student_management_backend.Core.Models.Submit", "Submit")
                        .WithOne("Review")
                        .HasForeignKey("student_management_backend.Core.Models.Review", "SubmitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("student_management_backend.Core.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Submit");

                    b.Navigation("User");
                });

            modelBuilder.Entity("student_management_backend.Core.Models.Schedule", b =>
                {
                    b.HasOne("student_management_backend.Core.Models.Class", "Class")
                        .WithOne("Schedule")
                        .HasForeignKey("student_management_backend.Core.Models.Schedule", "ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("student_management_backend.Core.Models.SchoolYear", "SchoolYear")
                        .WithMany("Schedules")
                        .HasForeignKey("SchoolYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("SchoolYear");
                });

            modelBuilder.Entity("student_management_backend.Core.Models.ScheduleSubject", b =>
                {
                    b.HasOne("student_management_backend.Core.Models.Schedule", "Schedule")
                        .WithMany("ScheduleSubjects")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("student_management_backend.Core.Models.Subject", "Subject")
                        .WithMany("ScheduleSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("student_management_backend.Core.Models.Submit", b =>
                {
                    b.HasOne("student_management_backend.Core.Models.Assignment", "Assignment")
                        .WithMany("Submits")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("student_management_backend.Core.Models.User", "Student")
                        .WithMany("Submits")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("student_management_backend.Core.Models.TeachClass", b =>
                {
                    b.HasOne("student_management_backend.Core.Models.Class", "Class")
                        .WithMany("TeachClasses")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("student_management_backend.Core.Models.User", "Teacher")
                        .WithMany("TeachClasses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("student_management_backend.Core.Models.User", b =>
                {
                    b.HasOne("student_management_backend.Core.Models.Class", "Class")
                        .WithMany("User")
                        .HasForeignKey("ClassId");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("student_management_backend.Core.Models.Assignment", b =>
                {
                    b.Navigation("Submits");
                });

            modelBuilder.Entity("student_management_backend.Core.Models.Class", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Schedule")
                        .IsRequired();

                    b.Navigation("TeachClasses");

                    b.Navigation("User");
                });

            modelBuilder.Entity("student_management_backend.Core.Models.Schedule", b =>
                {
                    b.Navigation("ScheduleSubjects");
                });

            modelBuilder.Entity("student_management_backend.Core.Models.SchoolYear", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("student_management_backend.Core.Models.Subject", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("ScheduleSubjects");
                });

            modelBuilder.Entity("student_management_backend.Core.Models.Submit", b =>
                {
                    b.Navigation("Review")
                        .IsRequired();
                });

            modelBuilder.Entity("student_management_backend.Core.Models.User", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Reviews");

                    b.Navigation("Submits");

                    b.Navigation("TeachClasses");
                });
#pragma warning restore 612, 618
        }
    }
}
