
namespace student_management_backend.Models;

public class Submit : AuditableEntity
{
    public int StudentId { get; set; }
    public int AssignmentId { get; set; }
    public string? Description { get; set; }
    public string? AttachFile { get; set; }

    public virtual User Student { get; private set; } = default!;
    public virtual Assignment Assignment { get; private set; } = default!;
    public virtual Review Review { get; private set; } = default!;
}
