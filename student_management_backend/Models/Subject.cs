
namespace student_management_backend.Models;

public class Subject : AuditableEntity
{
    public required string Title { get; set; }
    public string Description { get; set; } = default!;
    public virtual ICollection<ScheduleSubject> ScheduleSubjects { get; private set; } = default!;
    public virtual ICollection<Assignment> Assignments { get; private set; } = default!;
}
