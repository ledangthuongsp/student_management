using student_management_backend.Models;

public class RegisterRequest
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public EUserRole Role { get; set; }  // Thêm Role để xác định loại người dùng khi đăng ký
}
