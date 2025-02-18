﻿namespace student_management_backend.Config.Auth;

public class JwtSettings
{
    public string? Key { get; set; }
    public string? Issuer { get; set; }
    public int RefreshTokenExpirationInDays { get; set; }
    public int TokenExpirationInDays { get; set; }
    public int TokenExpirationInMinutes { get; set; }
}

public static class InternalClaims
{
    public const string Fullname = "fullName";
    public const string ImageUrl = "image_url";
}
