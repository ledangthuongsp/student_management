namespace student_management_backend.Core.Models;

public class TeachClass : AuditableEntity
{
    public required int ClassId { get; set; }
    public required int TeacherId { get; set; }
    public virtual User Teacher { get; private set; } = default!;
    public virtual Class Class { get; private set; } = default!;
}
