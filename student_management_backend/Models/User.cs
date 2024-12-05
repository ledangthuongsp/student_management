
namespace student_management_backend.Models;

public class User : AuditableEntity
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string FullName { get; set; }
    public required string PhoneNumber { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public EUserGender Gender { get; set; } = EUserGender.Male;
    public string? AvatarUrl { get; set; }
    public EUserRole Role { get; set; } = EUserRole.Student;
    public int ClassId { get; set; }
    public virtual Class Class { get; private set; } = default!;
    public virtual ICollection<TeachClass> TeachClasses { get; private set; } = default!;
    public virtual ICollection<Submit> Submits { get; private set; } = default!;
    public virtual ICollection<Review> Reviews { get; private set; } = default!;
    public virtual ICollection<Assignment> Assignments { get; private set; } = default!;
}
