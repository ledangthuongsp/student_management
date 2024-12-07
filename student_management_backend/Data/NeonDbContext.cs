using Microsoft.EntityFrameworkCore;
using student_management_backend.Models;
using student_management_backend.Seed;

public class NeonDbContext : DbContext
{
    public NeonDbContext(DbContextOptions<NeonDbContext> options) : base(options) { }

    public DbSet<User> User { get; set; }
    public DbSet<Assignment> Assignment { get; set; }
    public DbSet<Class> Class { get; set; }
    public DbSet<Review> Review { get; set; }
    public DbSet<Schedule> Schedule { get; set; }
    public DbSet<ScheduleSubject> ScheduleSubject { get; set; }
    public DbSet<SchoolYear> SchoolYear { get; set; }
    public DbSet<Subject> Subject { get; set; }
    public DbSet<Submit> Submit { get; set; }
    public DbSet<TeachClass> TeachClass { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Các cấu hình khác nếu cần
        // Đảm bảo tên bảng là "users" với chữ thường
        modelBuilder.Entity<User>(b => {
            b.ToTable("users");
            b.HasKey(x => x.Id);
            b.HasIndex(x => x.PhoneNumber).IsUnique();
            b.HasIndex(x => x.Email).IsUnique();
            b.HasOne(x => x.Class).WithMany(x => x.User).HasForeignKey(x => x.ClassId);
            b.HasMany(x => x.TeachClasses).WithOne(x => x.Teacher).HasForeignKey(x => x.TeacherId);
            b.HasMany(x => x.Submits).WithOne(x => x.Student).HasForeignKey(x => x.StudentId);
            b.HasMany(x => x.Reviews).WithOne(x => x.User).HasForeignKey(x => x.TeacherId);
            b.HasMany(x => x.Assignments).WithOne(x => x.User).HasForeignKey(x => x.TeacherId);
        });

        modelBuilder.Entity<Assignment>(b =>
        {
            b.ToTable("assignments");
            b.HasKey(x => x.Id);
            b.HasOne(x => x.Subject).WithMany(x => x.Assignments).HasForeignKey(x => x.SubjectId);
            b.HasOne(x => x.User).WithMany(x => x.Assignments).HasForeignKey(x => x.TeacherId);
            b.HasOne(x => x.Class).WithMany(x => x.Assignments).HasForeignKey(x => x.ClassId);
            b.HasMany(x => x.Submits).WithOne(x => x.Assignment).HasForeignKey(x => x.AssignmentId);
        });

        modelBuilder.Entity<Class>(b =>
        {
            b.ToTable("classes");
            b.HasKey(x => x.Id);
            b.HasMany(x => x.User).WithOne(x => x.Class).HasForeignKey(x => x.ClassId);
            b.HasMany(x => x.TeachClasses).WithOne(x => x.Class).HasForeignKey(x => x.ClassId);
            b.HasOne(x => x.Schedule).WithOne(x => x.Class).HasForeignKey<Schedule>(x => x.ClassId);
        });

        modelBuilder.Entity<Review>(b =>
        {
            b.ToTable("reviews");
            b.HasKey(x => x.Id);
            b.HasOne(x => x.Submit).WithOne(x => x.Review).HasForeignKey<Review>(x => x.SubmitId);
            b.HasOne(x => x.User).WithMany(x => x.Reviews).HasForeignKey(x => x.TeacherId);
        });

        modelBuilder.Entity<Schedule>(b =>
        {
            b.ToTable("schedules");
            b.HasKey(x => x.Id);
            b.HasOne(x => x.SchoolYear).WithMany(x => x.Schedules).HasForeignKey(x => x.SchoolYearId);
            b.HasOne(x => x.Class).WithOne(x => x.Schedule).HasForeignKey<Schedule>(x => x.ClassId);
            b.HasMany(x => x.ScheduleSubjects).WithOne(x => x.Schedule).HasForeignKey(x => x.ScheduleId);
        });

        modelBuilder.Entity<ScheduleSubject>(b =>
        {
            b.ToTable("schedule_subjects");
            b.HasKey(x => new { x.SubjectId, x.ScheduleId, x.DayOfWeek });
            b.HasOne(x => x.Subject).WithMany(x => x.ScheduleSubjects).HasForeignKey(x => x.SubjectId);
            b.HasOne(x => x.Schedule).WithMany(x => x.ScheduleSubjects).HasForeignKey(x => x.ScheduleId);
        });

        modelBuilder.Entity<SchoolYear>(b =>
        {
            b.ToTable("school_years");
            b.HasKey(x => x.Id);
            b.HasMany(x => x.Schedules).WithOne(x => x.SchoolYear).HasForeignKey(x => x.SchoolYearId);
            b.HasMany(x => x.Classes).WithOne(x => x.SchoolYear).HasForeignKey(x => x.SchoolYearId);
        });

        modelBuilder.Entity<Subject>(b =>
        {
            b.ToTable("subjects");
            b.HasKey(x => x.Id);
            b.HasMany(x => x.ScheduleSubjects).WithOne(x => x.Subject).HasForeignKey(x => x.SubjectId);
            b.HasMany(x => x.Assignments).WithOne(x => x.Subject).HasForeignKey(x => x.SubjectId);
        });

        modelBuilder.Entity<Submit>(b =>
        {
            b.ToTable("submits");
            b.HasKey(x => x.Id);
            b.HasOne(x => x.Student).WithMany(x => x.Submits).HasForeignKey(x => x.StudentId);
            b.HasOne(x => x.Assignment).WithMany(x => x.Submits).HasForeignKey(x => x.AssignmentId);
            b.HasOne(x => x.Review).WithOne(x => x.Submit).HasForeignKey<Review>(x => x.SubmitId);
        });

        modelBuilder.Entity<TeachClass>(b =>
        {
            b.ToTable("teach_classes");
            b.HasKey(x => new { x.TeacherId, x.ClassId });
            b.HasOne(x => x.Teacher).WithMany(x => x.TeachClasses).HasForeignKey(x => x.TeacherId);
            b.HasOne(x => x.Class).WithMany(x => x.TeachClasses).HasForeignKey(x => x.ClassId);
        });

        new DbInitializer(modelBuilder).Seed();
    }
}