namespace student_management_backend.DTOs.Response;

public class UserResponse
{
    public int Id { get; set; }
    public string Email { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string? AvatarUrl { get; set; }
    public ClassDetailResponse? Class { get; set; }
}
