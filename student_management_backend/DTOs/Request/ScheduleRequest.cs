namespace student_management_backend.DTOs.Request;

public class CreateScheduleRequest
{
    public required int ClassId { get; set; }
    public required int Grade { get; set; }
    public required DateTime StartApplyingDate { get; set; } = DateTime.UtcNow;
    public required DateTime EndApplyingDate { get; set; } = DateTime.UtcNow.AddYears(1);
}

public class GetScheduleInOneYearPeriod
{
    public int StartSchoolYear { get; set; }
    public int EndSchoolYear { get; set; }
}

public class GetScheduleByClassId
{
    public int? ClassId { get; set; }
    public int? StartSchoolYear { get; set; }
}

public class AddScheduleSubjectRequest
{
    public ICollection<AddScheduleSubjectDetail> Subjects { get; set; } = default!;
}

public class AddScheduleSubjectDetail
{
    public int SubjectId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public int StartPeriod { get; set; }
    public int EndPeriod { get; set; }
}