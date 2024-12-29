namespace student_management_backend.Core.Models;

public class Schedule : AuditableEntity
{
    public int SchoolYearId { get; set; }
    public int ClassId { get; set; }
    public virtual SchoolYear SchoolYear { get; private set; } = default!;
    public virtual Class Class { get; set; } = default!;

    public virtual ICollection<ScheduleSubject> ScheduleSubjects { get; private set; } = default!;
}
