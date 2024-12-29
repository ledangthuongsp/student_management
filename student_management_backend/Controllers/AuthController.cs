using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using student_management_backend.Common.Exceptions;
using student_management_backend.Core.Models;
using Microsoft.AspNetCore.Authorization;

namespace student_management_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly NeonDbContext _context;
        private readonly OtpService _otpService;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthController(NeonDbContext context, OtpService otpService, IJwtTokenService jwtTokenService)
        {
            _context = context;
            _otpService = otpService;
            _jwtTokenService = jwtTokenService;
        }

        // Đăng ký người dùng mới
        [Authorize(Roles = nameof(EUserRole.Council))]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var currentUser = User;

            if (request.Password != request.ConfirmPassword)
            {
                throw new BadRequestException("Password and Confirm Password do not match.");
            }

            if (await _context.User.AnyAsync(u => u.Email == request.Email))
            {
                throw new BadRequestException("Email already exists.");
            }

            if (!Enum.IsDefined(typeof(EUserRole), request.Role))
            {
                throw new BadRequestException("Invalid role.");
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                Password = hashedPassword,
                Role = request.Role,
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();
            
            return Ok("User registered successfully.");
        }

        // Đăng nhập
        [HttpPost("sign-in")]
        public async Task<LoginResponse> SignIn([FromBody] LoginRequest request)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == request.Email) ?? throw new NotFoundException("User not found.");
            
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                throw new UnauthorizedException("Invalid password.");
            }

            var token = _jwtTokenService.GenerateToken(user);

            return new LoginResponse() 
            {   
                Id = user.Id,
                Role = user.Role,
                FullName = user.FullName,
                Token = token.token,
                TokenExpiryTime = token.tokeExpiryTime
            };
        }

        // Quên mật khẩu - Gửi OTP
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == request.Email) ?? throw new NotFoundException("User not found.");
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
                throw new BadRequestException("Invalid or expired OTP.");
            }

            return Ok("OTP verified successfully.");
        }

        // Đặt lại mật khẩu
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            if (request.NewPassword != request.ConfirmNewPassword)
            {
                throw new BadRequestException("New Password and Confirm Password do not match.");
            }

            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == request.Email) ?? throw new NotFoundException("User not found."); // Đảm bảo tên bảng là "User" không phải "Users"

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
    }
}
