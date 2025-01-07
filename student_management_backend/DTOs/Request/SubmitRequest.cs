namespace student_management_backend.DTOs.Request;

public class CreatSubmitRequest
{
    public int AssignmentId { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public string? FileUrl { get; set; }
}

public class UpdateSubmitRequest
{
    public string? Title { get; set; } = default!;
    public string? Description { get; set; }
    public string? FileUrl { get; set; }
}