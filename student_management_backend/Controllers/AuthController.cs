using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly NeonDbContext _neonContext;
    private readonly SupabaseDbContext _supabaseContext;

    public AuthController(NeonDbContext neonContext, SupabaseDbContext supabaseContext)
    {
        _neonContext = neonContext;
        _supabaseContext = supabaseContext;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(User user)
    {
        if (_neonContext.Users.Any(u => u.Username == user.Username))
            return BadRequest("User already exists.");

        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        _neonContext.Users.Add(user);
        await _neonContext.SaveChangesAsync();
        return Ok("User registered successfully.");
    }

    [HttpPost("login")]
    public IActionResult Login(User loginRequest)
    {
        var user = _neonContext.Users.FirstOrDefault(u => u.Username == loginRequest.Username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
            return Unauthorized("Invalid credentials.");

        return Ok("Login successful.");
    }

    [HttpPost("register-supabase")]
    public async Task<IActionResult> RegisterSupabase(User user)
    {
        if (_supabaseContext.Users.Any(u => u.Username == user.Username))
            return BadRequest("User already exists.");

        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        _supabaseContext.Users.Add(user);
        await _supabaseContext.SaveChangesAsync();
        return Ok("User registered successfully on Supabase.");
    }

    [HttpPost("login-supabase")]
    public IActionResult LoginSupabase(User loginRequest)
    {
        var user = _supabaseContext.Users.FirstOrDefault(u => u.Username == loginRequest.Username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
            return Unauthorized("Invalid credentials for Supabase.");

        return Ok("Login successful on Supabase.");
    }
}