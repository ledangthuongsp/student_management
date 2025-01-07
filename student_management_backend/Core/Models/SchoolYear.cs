namespace student_management_backend.Core.Models;
public class SchoolYear : AuditableEntity
{
    public required int StartSchoolYear { get; set; }
    public required int EndSchoolYear { get; set; }
    public virtual ICollection<Schedule> Schedules { get; private set; } = default!;
    public virtual ICollection<Class> Classes { get; private set; } = default!;
}
