using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using student_management_backend.Models;

namespace YourProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly NeonDbContext _context;

        public AuthController(NeonDbContext context)
        {
            _context = context;
        }

        // Sign Up Endpoint
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (_context.User.Any(u => u.Email == request.Email))
                return BadRequest("User already exists.");

            var newUser = new User
            {
                Email = request.Email,
                FullName = request.FullName,
                PhoneNumber = request.PhoneNumber,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                DateOfBirth = request.DateOfBirth
            };

            _context.User.Add(newUser);
            await _context.SaveChangesAsync();

            var response = new LoginResponse
            {
                Id = newUser.Id,
                Role = newUser.Role
            };

            return Ok(response);
        }

        // Sign In Endpoint
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _context.User.FirstOrDefault(u => u.Email == request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                return Unauthorized("Invalid credentials.");

            var response = new LoginResponse
            {
                Id = user.Id,
                Role = user.Role
            };

            return Ok(response);
        }
    }
}
