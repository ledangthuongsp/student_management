public class RegisterRequest
{
    public required string Password { get; set; }
    public required string Email { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required string FullName { get; set; }
    public required string PhoneNumber { get; set; }
}
