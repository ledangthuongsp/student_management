using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using student_management_backend.Models;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly NeonDbContext _context;
    private readonly OtpService _otpService;

    public AuthController(NeonDbContext context, OtpService otpService)
    {
        _context = context;
        _otpService = otpService;
    }

    // Đăng ký người dùng mới
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var currentUser = GetCurrentUser();  // Giả sử bạn có cách lấy thông tin người đăng nhập hiện tại

        // Kiểm tra nếu người đăng nhập không phải là Council
        if (currentUser.Role != EUserRole.Council)
        {
            return Unauthorized("You do not have permission to add users.");
        }

        // Kiểm tra nếu mật khẩu và xác nhận mật khẩu không khớp
        if (request.Password != request.ConfirmPassword)
        {
            return BadRequest("Password and Confirm Password do not match.");
        }

        // Kiểm tra nếu email đã tồn tại trong hệ thống
        if (await _context.Users.AnyAsync(u => u.Email == request.Email))
        {
            return BadRequest("Email already exists.");
        }

        // Hash mật khẩu trước khi lưu vào cơ sở dữ liệu
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = new User
        {
            FullName = request.FullName,
            Email = request.Email,
            Password = hashedPassword,
            Role = request.Role  // Lưu vai trò người dùng
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok("User registered successfully.");
    }

    // Đăng nhập
    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] LoginRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
        if (user == null)
        {
            return NotFound("User not found.");
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            return Unauthorized("Invalid password.");
        }

        return Ok("User signed in successfully.");
    }

    // Quên mật khẩu - Gửi OTP
    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

        if (user == null)
        {
            return NotFound("User not found.");
        }

        var otp = _otpService.GenerateOtp(request.Email);
        SendEmail(request.Email, otp);

        return Ok("OTP has been sent to your email.");
    }

    // Xác minh OTP
    [HttpPost("verify-otp")]
    public IActionResult VerifyOtp([FromBody] VerifyOtpRequest request)
    {
        if (!_otpService.ValidateOtp(request.Email, request.Otp))
        {
            return BadRequest("Invalid or expired OTP.");
        }

        return Ok("OTP verified successfully.");
    }

    // Đặt lại mật khẩu
    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
    {
        if (request.NewPassword != request.ConfirmNewPassword)
        {
            return BadRequest("New Password and Confirm Password do not match.");
        }

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

        if (user == null)
        {
            return NotFound("User not found.");
        }

        user.Password = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
        await _context.SaveChangesAsync();

        return Ok("Password reset successfully.");
    }

    // Gửi email chứa OTP
    private void SendEmail(string toEmail, string otp)
    {
        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new System.Net.NetworkCredential("adodoo.hr.company@gmail.com", "jozqsqffwavpnfeq"),
            EnableSsl = true,
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress("adodoo.hr.company@gmail.com"),
            Subject = "Your OTP Code",
            Body = $"Your OTP is: {otp}. It is valid for 5 minutes.",
            IsBodyHtml = false,
        };

        mailMessage.To.Add(toEmail);
        smtpClient.Send(mailMessage);
    }

    // Giả sử bạn có một phương thức để lấy thông tin người dùng hiện tại
    private User GetCurrentUser()
    {
        // Cách lấy thông tin người dùng hiện tại (có thể từ session hoặc JWT token)
        return new User
        {
            Email = "council@example.com",
            Role = EUserRole.Council
        };
    }
}
