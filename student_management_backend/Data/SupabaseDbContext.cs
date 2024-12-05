using Microsoft.EntityFrameworkCore;
using student_management_backend.Models;

public class SupabaseDbContext : DbContext
{
    public SupabaseDbContext(DbContextOptions<SupabaseDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}