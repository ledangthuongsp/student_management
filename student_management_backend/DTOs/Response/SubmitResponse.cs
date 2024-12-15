namespace student_management_backend.DTOs.Response;

public class SubmitResponse
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public string? AttachFile { get; set; }
    public UserResponse? Owner { get; set; } = default!;
}
