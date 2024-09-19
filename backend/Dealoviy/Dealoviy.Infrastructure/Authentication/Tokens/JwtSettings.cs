namespace Dealoviy.Infrastructure.Authentication.Tokens;

public class JwtSettings
{
    public static string SectionName { get; } = "JwtSettings";
    public string Secret { get; set; } = null!;
    public int ExpirationTimeInMinutes { get; init; }
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
}