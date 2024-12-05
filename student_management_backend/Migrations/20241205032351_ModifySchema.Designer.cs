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
    [Migration("20241205032351_ModifySchema")]
    partial class ModifySchema
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
                });

            modelBuilder.Entity("student_management_backend.Models.ScheduleSubject", b =>
                {
                    b.Property<int>("SubjectId")
                        .HasColumnType("integer");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("integer");

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

                    b.HasKey("SubjectId", "ScheduleId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("schedule_subjects", (string)null);
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

                    b.Property<int>("EndSchoolYear")
                        .HasColumnType("integer");

                    b.Property<int>("StartSchoolYear")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("school_years", (string)null);
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
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("subjects", (string)null);
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
                });

            modelBuilder.Entity("student_management_backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("text");

                    b.Property<int>("ClassId")
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
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("users", (string)null);
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
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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