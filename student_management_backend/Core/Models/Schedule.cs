namespace student_management_backend.Core.Models;

public class Schedule : AuditableEntity
{
    public int ClassId { get; set; }
    public int Grade { get; set; }
    public DateTime StartApplyingDate { get; set; }
    public DateTime EndApplyingDate { get; set; }
    public virtual Class Class { get; set; } = default!;
    public virtual ICollection<ScheduleSubject> ScheduleSubjects { get; private set; } = default!;
}
