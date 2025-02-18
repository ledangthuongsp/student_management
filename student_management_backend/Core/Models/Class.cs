namespace student_management_backend.Core.Models;

public class Class : AuditableEntity
{
    public required string ClassName { get; set; }
    public int SchoolYearId { get; set; }
    public required int Grade { get; set; }
    public virtual ICollection<User> User { get; private set; } = default!;
    public virtual ICollection<Assignment> Assignments { get; private set; } = default!;
    public virtual ICollection<TeachClass> TeachClasses { get; private set; } = default!;
    public virtual ICollection<Schedule> Schedules { get; private set; } = default!;
    public virtual SchoolYear SchoolYear { get; set; } = default!;
}
