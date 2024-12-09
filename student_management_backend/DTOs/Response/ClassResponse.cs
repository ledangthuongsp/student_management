namespace student_management_backend.DTOs.Response;

public class ClassDetailResponse
{
    public int Id { get; set; } = default!;
    public string ClassName { get; set; } = default!;
    public int Grade { get; set; } = default!;
    public SchoolYearResponse? SchoolYear { get; set; } = default!;
}
