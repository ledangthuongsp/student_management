using System.Collections.ObjectModel;

namespace student_management_backend.Core.Models;

public class Assignment : AuditableEntity
{
    public required string Title { get; set; }
    public int Grade { get; set; }
    public int Semester { get; set; }
    public EAssignmentType Type { get; set; } = EAssignmentType.FifteenMinute;
    public string Description { get; set; } = default!;
    public DateTime DueDate { get; set; }
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }
    public int ClassId { get; set; }
    public virtual Subject Subject { get; private set; } = default!;
    public virtual User User { get; private set; } = default!;
    public virtual Class Class { get; private set; } = default!;
    public virtual ICollection<Submit> Submits { get; private set; } = default!;
}
