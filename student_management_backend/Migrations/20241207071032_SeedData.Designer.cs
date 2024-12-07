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
    [Migration("20241207071032_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("student_management_backend.Models.Assignment", b =>
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

            modelBuilder.Entity("student_management_backend.Models.Class", b =>
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
                            CreatedDate = new DateTime(2024, 12, 7, 7, 10, 30, 953, DateTimeKind.Utc).AddTicks(3285),
                            Grade = 10,
                            SchoolYearId = 1
                        });
                });

            modelBuilder.Entity("student_management_backend.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
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

            modelBuilder.Entity("student_management_backend.Models.Schedule", b =>
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
                            CreatedDate = new DateTime(2024, 12, 7, 7, 10, 30, 953, DateTimeKind.Utc).AddTicks(3319),
                            SchoolYearId = 1
                        });
                });

            modelBuilder.Entity("student_management_backend.Models.ScheduleSubject", b =>
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
                            CreatedDate = new DateTime(2024, 12, 7, 7, 10, 30, 953, DateTimeKind.Utc).AddTicks(3382),
                            EndPeriod = 3,
                            Id = 1,
                            StartPeriod = 1
                        });
                });

            modelBuilder.Entity("student_management_backend.Models.SchoolYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EndSchoolYear")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StartSchoolYear")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("school_years", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 12, 7, 7, 10, 30, 953, DateTimeKind.Utc).AddTicks(3003),
                            EndSchoolYear = "2026",
                            StartSchoolYear = "2023"
                        });
                });

            modelBuilder.Entity("student_management_backend.Models.Subject", b =>
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
                            CreatedDate = new DateTime(2024, 12, 7, 7, 10, 30, 953, DateTimeKind.Utc).AddTicks(3351),
                            Title = "Toán"
                        });
                });

            modelBuilder.Entity("student_management_backend.Models.Submit", b =>
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

            modelBuilder.Entity("student_management_backend.Models.TeachClass", b =>
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
                            CreatedDate = new DateTime(2024, 12, 7, 7, 10, 31, 668, DateTimeKind.Utc).AddTicks(2135),
                            Id = 1
                        });
                });

            modelBuilder.Entity("student_management_backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

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
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
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
                            CreatedDate = new DateTime(2024, 12, 7, 7, 10, 30, 953, DateTimeKind.Utc).AddTicks(3412),
                            DateOfBirth = new DateTime(2024, 12, 7, 7, 10, 30, 953, DateTimeKind.Utc).AddTicks(3415),
                            Email = "principal@school.com",
                            FullName = "Trinh Dinh A",
                            Gender = 0,
                            Password = "$2a$11$A.JHHTDI3uuSe6uFo/1mL.lMUmsKN/QmJsMYRhjn2Mhnuf10vbKAi",
                            PhoneNumber = "0000000001",
                            Role = 2
                        },
                        new
                        {
                            Id = 2,
                            ClassId = 1,
                            CreatedDate = new DateTime(2024, 12, 7, 7, 10, 31, 124, DateTimeKind.Utc).AddTicks(8389),
                            DateOfBirth = new DateTime(2024, 12, 7, 7, 10, 31, 124, DateTimeKind.Utc).AddTicks(8395),
                            Email = "teacher.001@school.com",
                            FullName = "Nguyen Van B",
                            Gender = 0,
                            Password = "$2a$11$UmA2oG698KWscNALy37i6ez56U5grTqtmHA2Ihk02xEOB12s2p4U2",
                            PhoneNumber = "0000000002",
                            Role = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 12, 7, 7, 10, 31, 279, DateTimeKind.Utc).AddTicks(1940),
                            DateOfBirth = new DateTime(2024, 12, 7, 7, 10, 31, 279, DateTimeKind.Utc).AddTicks(1948),
                            Email = "teacher.002@school.com",
                            FullName = "Tran Thi C",
                            Gender = 0,
                            Password = "$2a$11$STKsMobYZ5aMhPPjWClu2.P1e4V5OU5eTQLRT4hBLbX6wMU6Vyt02",
                            PhoneNumber = "0000000003",
                            Role = 1
                        },
                        new
                        {
                            Id = 4,
                            ClassId = 1,
                            CreatedDate = new DateTime(2024, 12, 7, 7, 10, 31, 455, DateTimeKind.Utc).AddTicks(8615),
                            DateOfBirth = new DateTime(2024, 12, 7, 7, 10, 31, 455, DateTimeKind.Utc).AddTicks(8623),
                            Email = "student.001@school.com",
                            FullName = "Nguyen Duc D",
                            Gender = 0,
                            Password = "$2a$11$h0I3/b2siuwLzV60JbAvQ.LELfpb.vXzgZAlbP5A6n4GJTu.hvH5S",
                            PhoneNumber = "0000000004",
                            Role = 0
                        });
                });

            modelBuilder.Entity("student_management_backend.Models.Assignment", b =>
                {
                    b.HasOne("student_management_backend.Models.Class", "Class")
                        .WithMany("Assignments")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("student_management_backend.Models.Subject", "Subject")
                        .WithMany("Assignments")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("student_management_backend.Models.User", "User")
                        .WithMany("Assignments")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Subject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("student_management_backend.Models.Class", b =>
                {
                    b.HasOne("student_management_backend.Models.SchoolYear", "SchoolYear")
                        .WithMany("Classes")
                        .HasForeignKey("SchoolYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SchoolYear");
                });

            modelBuilder.Entity("student_management_backend.Models.Review", b =>
                {
                    b.HasOne("student_management_backend.Models.Submit", "Submit")
                        .WithOne("Review")
                        .HasForeignKey("student_management_backend.Models.Review", "SubmitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("student_management_backend.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Submit");

                    b.Navigation("User");
                });

            modelBuilder.Entity("student_management_backend.Models.Schedule", b =>
                {
                    b.HasOne("student_management_backend.Models.Class", "Class")
                        .WithOne("Schedule")
                        .HasForeignKey("student_management_backend.Models.Schedule", "ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("student_management_backend.Models.SchoolYear", "SchoolYear")
                        .WithMany("Schedules")
                        .HasForeignKey("SchoolYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("SchoolYear");
                });

            modelBuilder.Entity("student_management_backend.Models.ScheduleSubject", b =>
                {
                    b.HasOne("student_management_backend.Models.Schedule", "Schedule")
                        .WithMany("ScheduleSubjects")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("student_management_backend.Models.Subject", "Subject")
                        .WithMany("ScheduleSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("student_management_backend.Models.Submit", b =>
                {
                    b.HasOne("student_management_backend.Models.Assignment", "Assignment")
                        .WithMany("Submits")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("student_management_backend.Models.User", "Student")
                        .WithMany("Submits")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("student_management_backend.Models.TeachClass", b =>
                {
                    b.HasOne("student_management_backend.Models.Class", "Class")
                        .WithMany("TeachClasses")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("student_management_backend.Models.User", "Teacher")
                        .WithMany("TeachClasses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("student_management_backend.Models.User", b =>
                {
                    b.HasOne("student_management_backend.Models.Class", "Class")
                        .WithMany("User")
                        .HasForeignKey("ClassId");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("student_management_backend.Models.Assignment", b =>
                {
                    b.Navigation("Submits");
                });

            modelBuilder.Entity("student_management_backend.Models.Class", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Schedule")
                        .IsRequired();

                    b.Navigation("TeachClasses");

                    b.Navigation("User");
                });

            modelBuilder.Entity("student_management_backend.Models.Schedule", b =>
                {
                    b.Navigation("ScheduleSubjects");
                });

            modelBuilder.Entity("student_management_backend.Models.SchoolYear", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("student_management_backend.Models.Subject", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("ScheduleSubjects");
                });

            modelBuilder.Entity("student_management_backend.Models.Submit", b =>
                {
                    b.Navigation("Review")
                        .IsRequired();
                });

            modelBuilder.Entity("student_management_backend.Models.User", b =>
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
