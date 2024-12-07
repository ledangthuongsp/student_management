namespace student_management_backend.Models;
public class SchoolYear : AuditableEntity
{
    public required string StartSchoolYear { get; set; }
    public required string EndSchoolYear { get; set; }
    public virtual ICollection<Schedule> Schedules { get; private set; } = default!;
    public virtual ICollection<Class> Classes { get; private set; } = default!;
}
