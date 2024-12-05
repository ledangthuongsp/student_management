
namespace student_management_backend.Models;

public class ScheduleSubject : AuditableEntity
{
    public int SubjectId { get; set; }
    public int ScheduleId { get; set; }
    public required DayOfWeek DayOfWeek { get; set; }
    public required int StartPeriod { get; set; }
    public required int EndPeriod { get; set; }
    public virtual Subject Subject { get; private set; } = default!;
    public virtual Schedule Schedule { get; private set; } = default!;
}
