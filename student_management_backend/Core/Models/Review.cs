namespace student_management_backend.Core.Models;

public class Review : AuditableEntity
{
    public required double Score { get; set; }
    public string? Comment { get; set; } = default!;
    public int TeacherId { get; set; }
    public int SubmitId { get; set; }

    public virtual Submit Submit { get; private set; } = default!;
    public virtual User User { get; private set; } = default!;
}
