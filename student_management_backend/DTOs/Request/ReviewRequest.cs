namespace student_management_backend.DTOs.Request;

public class CreateReviewRequest
{
    public int SubmitId { get; set; }
    public int TeacherId { get; set; }
    public double Score { get; set; }
    public string? Comment { get; set; }
}

public class UpdateReviewRequest
{
    public double? Score { get; set; }
    public string? Comment { get; set; }
}
