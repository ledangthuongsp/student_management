namespace student_management_backend.DTOs.Response;

public class SchoolYearResponse
{
    public int SchoolYearId { get; set; }
    public int StartSchoolYear { get; set; } = default!;
    public int EndSchoolYear { get; set; } = default!;
}
