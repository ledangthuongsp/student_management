namespace student_management_backend.DTOs.Response;

public class ReviewResponse
{
    public int Id { get; set; }
    public double Score { get; set; } 
    public UserResponse Teacher { get; set; } = default!;
}
