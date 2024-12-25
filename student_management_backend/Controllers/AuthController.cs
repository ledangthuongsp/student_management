using Microsoft.AspNetCore.Mvc;
using student_management_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

namespace student_management_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly NeonDbContext _context;
        private readonly OtpService _otpService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthController(NeonDbContext context, OtpService otpService, IPasswordHasher passwordHasher)
        {
            _context = context;
            _otpService = otpService;
            _passwordHasher = passwordHasher;
        }

        // Đăng ký người dùng mới
        [HttpPost("register")] public async Task<IActionResult> Register([FromBody] RegisterRequest request, [FromQuery] EUserRole? role) { 
            var currentUser = await GetCurrentUser(); 
            // Lấy thông tin người đăng nhập hiện tại 
            if (currentUser?.Role != EUserRole.Council) { 
                return Unauthorized("You do not have permission to add users."); 
            } 
            if (request.Password != request.ConfirmPassword) { 
                return BadRequest("Password and Confirm Password do not match."); 
            } 
            if (await _context.User.AnyAsync(u => u.Email == request.Email)) {
                return BadRequest("Email already exists."); 
            } // Kiểm tra và xử lý Role nếu được truyền từ query string (FromQuery) 
            if (!role.HasValue || !Enum.IsDefined(typeof(EUserRole), role.Value)) { 
                return BadRequest("Invalid role."); 
                } 
            var hashedPassword = _passwordHasher.HashPassword(request.Password); 
            var user = new User { 
                FullName = request.FullName, 
                Email = request.Email, 
                Password = hashedPassword, 
                Role = role.Value, 
                }; 
            _context.User.Add(user); await _context.SaveChangesAsync(); 
            return Ok("User registered successfully.");
        }

        // Đăng nhập
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] LoginRequest request)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            if (!_passwordHasher.VerifyPassword(request.Password, user.Password))
            {
                return Unauthorized("Invalid password.");
            }

            return Ok("User signed in successfully.");
        }

        // Quên mật khẩu - Gửi OTP
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == request.Email);

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

            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == request.Email); // Đảm bảo tên bảng là "User" không phải "Users"

            if (user == null)
            {
                return NotFound("User not found.");
            }

            user.Password = _passwordHasher.HashPassword(request.NewPassword);
            await _context.SaveChangesAsync();

            return Ok("Password reset successfully.");
        }

        // Gửi email chứa OTP
        private void SendEmail(string toEmail, string otp)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("adodoo.hr.company@gmail.com", "jozqsqffwavpnfeq"),
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
        private async Task<User> GetCurrentUser()
        {
            var email = User?.Identity?.Name;  // Hoặc lấy từ JWT token, session, v.v.

            if (string.IsNullOrEmpty(email))
            {
                return null; // Nếu không tìm thấy email người dùng, trả về null.
            }

            var currentUser = await _context.User.FirstOrDefaultAsync(u => u.Email == email);

            return currentUser;
        }
    }
}