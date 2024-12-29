using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using student_management_backend.Config.Auth;
using student_management_backend.Core.Authorization;
using student_management_backend.Core.Models;

public record TokenResponse(string token, DateTime tokeExpiryTime);

public interface IJwtTokenService
{
    TokenResponse GenerateToken(User user);
}

public class JwtTokenService : IJwtTokenService
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenService(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    private SigningCredentials GetSigningCredentials()
    {
        if (string.IsNullOrEmpty(_jwtSettings.Key))
        {
            throw new InvalidOperationException("No Key defined in JwtSettings config.");
        }

        byte[] secret = Encoding.UTF8.GetBytes(_jwtSettings.Key);
        return new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256);
    }

    public TokenResponse GenerateToken(User user)
    {
        var claims = GetClaims(user);
        var credentials = GetSigningCredentials();

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(_jwtSettings.TokenExpirationInDays),
            signingCredentials: credentials,
            issuer: _jwtSettings.Issuer
        );

        return new TokenResponse(
            new JwtSecurityTokenHandler().WriteToken(token),
            DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpirationInMinutes)
        );
    }

    private IEnumerable<Claim> GetClaims(User user) =>
    new List<Claim>
    {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email ?? string.Empty),
            new(ClaimTypes.MobilePhone, user.PhoneNumber ?? string.Empty),
            new(ClaimTypes.Role, user.Role.ToString()),
            new(InternalClaims.Fullname, $"{user.FullName}"),
            new(InternalClaims.ImageUrl, user.AvatarUrl ?? string.Empty),
    };
}
