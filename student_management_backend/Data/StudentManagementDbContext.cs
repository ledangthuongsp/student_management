using Microsoft.EntityFrameworkCore;

public class StudentManagementDbContext : DbContext
{
    // public DbSet<Student> Students { get; set; } // Ví dụ về một DbSet cho bảng Students

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");
        optionsBuilder.UseNpgsql(connectionString);
    }
}
