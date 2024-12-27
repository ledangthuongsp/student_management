
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace student_management_backend.Models;

public class User : AuditableEntity
{   
    [ProtectedPersonalData]
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? FullName { get; set; }
    [MaxLength(10)]
    [ProtectedPersonalData]
    public string? PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public EUserGender Gender { get; set; } = EUserGender.Male;
    public string? Address {get; set;}
    public string? AvatarUrl { get; set; }
    public EUserRole Role { get; set; } = EUserRole.Student;
    public int? ClassId { get; set; }
    public virtual Class Class { get; private set; } = default!;
    public virtual ICollection<TeachClass> TeachClasses { get; private set; } = default!;
    public virtual ICollection<Submit> Submits { get; private set; } = default!;
    public virtual ICollection<Review> Reviews { get; private set; } = default!;
    public virtual ICollection<Assignment> Assignments { get; private set; } = default!;
}
