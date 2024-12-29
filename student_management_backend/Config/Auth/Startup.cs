using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace student_management_backend.Config.Auth;


internal static class Startup
{
    internal static IServiceCollection AddJwtAuth(this IServiceCollection services, IConfiguration config)
    {

        services.Configure<JwtSettings>(config.GetSection(nameof(JwtSettings)));
        var jwtSettings = config.GetSection(nameof(JwtSettings)).Get<JwtSettings>();

        if (string.IsNullOrEmpty(jwtSettings?.Key))
            throw new InvalidOperationException("No Key defined in JwtSettings config.");

        byte[] key = Encoding.ASCII.GetBytes(jwtSettings.Key);

        return services
            .AddAuthentication(authentication =>
            {
                authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(bearer =>
            {
                bearer.RequireHttpsMetadata = false;
                bearer.SaveToken = true;
                bearer.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero,
                    RoleClaimType = ClaimTypes.Role,
                };
            })
            .Services;
    }
}