using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using student_management_backend.Core.Models;

namespace student_management_backend.Seed;

public class DbInitializer
{
    private readonly ModelBuilder _modelBuilder;

    public DbInitializer(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    public void Seed()
    {
        _modelBuilder.Entity<SchoolYear>().HasData(
            new SchoolYear()
            {
                Id = 1,
                StartSchoolYear = "2023",
                EndSchoolYear = "2026",
            });

        _modelBuilder.Entity<Class>().HasData(
            new Class()
            {
                Id = 1,
                ClassName = "A4",
                Grade = 10,
                SchoolYearId = 1
            });

        _modelBuilder.Entity<Schedule>().HasData(
            new Schedule()
            {
                Id = 1,
                SchoolYearId = 1,
                ClassId = 1,
            });

        _modelBuilder.Entity<Subject>().HasData(
            new Subject()
            {
                Id = 1,
                Title = "Toán",
            });

        _modelBuilder.Entity<ScheduleSubject>().HasData(
            new ScheduleSubject()
            {
                Id = 1,
                ScheduleId = 1,
                SubjectId = 1,
                DayOfWeek = DayOfWeek.Monday,
                StartPeriod = 1,
                EndPeriod = 3
            });

        _modelBuilder.Entity<User>().HasData(
            new User()
            {
                Id = 1,
                Email = "principal@school.com",
                FullName = "Trinh Dinh A",
                DateOfBirth = DateTime.UtcNow,
                Password = BCrypt.Net.BCrypt.HashPassword("thisispassword"),
                PhoneNumber = "0000000001",
                Role = EUserRole.Council,
                Gender = EUserGender.Male,
            },
            new User()
            {
                Id = 2,
                Email = "teacher.001@school.com",
                FullName = "Nguyen Van B",
                DateOfBirth = DateTime.UtcNow,
                Password = BCrypt.Net.BCrypt.HashPassword("thisispassword"),
                PhoneNumber = "0000000002",
                Role = EUserRole.Teacher,
                Gender = EUserGender.Male,
                ClassId = 1,
            },
            new User()
            {
                Id = 3,
                Email = "teacher.002@school.com",
                FullName = "Tran Thi C",
                DateOfBirth = DateTime.UtcNow,
                Password = BCrypt.Net.BCrypt.HashPassword("thisispassword"),
                PhoneNumber = "0000000003",
                Role = EUserRole.Teacher,
                Gender = EUserGender.Male,
            },
            new User()
            {
                Id = 4,
                Email = "student.001@school.com",
                FullName = "Nguyen Duc D",
                DateOfBirth = DateTime.UtcNow,
                Password = BCrypt.Net.BCrypt.HashPassword("thisispassword"),
                PhoneNumber = "0000000004",
                Role = EUserRole.Student,
                Gender = EUserGender.Male,
                ClassId = 1,
            });

        _modelBuilder.Entity<TeachClass>().HasData(
            new TeachClass()
            {
                Id = 1,
                TeacherId = 3,
                ClassId = 1
            });

    }

}
