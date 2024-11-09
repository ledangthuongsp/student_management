using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;

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
            if (_context.Users.Any(u => u.Username == request.Username))
                return BadRequest("User already exists.");

            var newUser = new User
            {
                Username = request.Username,
                Email = request.Email,
                DayOfBirth = request.DateOfBirth,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            var response = new LoginResponse
            {
                Id = newUser.Id,
                Username = newUser.Username
            };

            return Ok(response);
        }

        // Sign In Endpoint
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == request.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                return Unauthorized("Invalid credentials.");

            var response = new LoginResponse
            {
                Id = user.Id,
                Username = user.Username
            };

            return Ok(response);
        }
    }
}
