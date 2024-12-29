using student_management_backend.Core.Models;

public class LoginResponse
{
    public int Id { get; set; }
    public EUserRole Role { get; set; }
    public string? FullName { get; set; } = default!;
    public string Token { get; set; } = default!;
    public DateTime TokenExpiryTime { get; set; } = default!;
}
