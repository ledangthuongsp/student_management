using Microsoft.AspNetCore.Identity;
using student_management_backend.Models;

public class PasswordHasher : IPasswordHasher
{
    private readonly PasswordHasher<User> _passwordHasher;

    public PasswordHasher()
    {
        _passwordHasher = new PasswordHasher<User>();
    }

    public string HashPassword(string password)
    {
        var user = new User(); // Đối tượng User để sử dụng trong PasswordHasher
        return _passwordHasher.HashPassword(user, password);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        var user = new User(); // Đối tượng User để sử dụng trong PasswordHasher
        var result = _passwordHasher.VerifyHashedPassword(user, hashedPassword, password);
        return result == PasswordVerificationResult.Success;
    }
}
