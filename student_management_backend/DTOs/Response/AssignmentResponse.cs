using student_management_backend.Models;

namespace student_management_backend.DTOs.Response;

public class AssignmentDetailTeacherResponse
{
    public string FullName { get; set; } = default!;
}

public class AssignmentDetailSubjectResponse
{
    public string Title { get; set; } = default!;
}

public class AssignmentDetailClassResponse
{
    public string ClassName { get; set; } = default!;
}


public class AssignmentDetailResponse
{
    public int Id { get; set; } = default!;
    public string Title { get; set; } = default!;
    public int Grade { get; set; }
    public int Semester { get; set; }
    public string Type { get; set; } = nameof(EAssignmentType.FifteenMinute);
    public string Description { get; set; } = default!;
    public DateTime DueDate { get; set; }
    public AssignmentDetailClassResponse Classroom { get; set; } = default!;
    public AssignmentDetailSubjectResponse Subject { get; set; } = default!;
    public AssignmentDetailTeacherResponse Teacher { get; set; } = default!;
}
