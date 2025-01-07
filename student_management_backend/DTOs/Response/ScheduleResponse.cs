namespace student_management_backend.DTOs.Response;

public class ScheduleDetailResponse
{
    public int ScheduleId { get; set; }
    public int Grade { get; set; }
    public DateTime StartApplyingDate { get; set; }
    public DateTime EndApplyingDate { get; set; }
    public ICollection<ScheduleSubjectResponse> Subjects { get; set; } = default!;
    public SchoolYearResponse SchoolYear { get; set; } = default!;
    public ClassDetailResponse Class { get; set; } = default!;
}

public class ScheduleSubjectResponse
{
    public int SubjectId { get; set; }
    public required string Title { get; set; }
    public required string DayOfWeek { get; set; }
    public required int StartPeriod { get; set; }
    public required int EndPeriod { get; set; }
}