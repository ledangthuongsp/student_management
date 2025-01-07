using student_management_backend.Core.Models;

namespace student_management_backend.DTOs.Request;

public class CreateAssignmentRequest
{
    public string Title { get; set; } = default!;
    public int Grade { get; set; } = 10;
    public int Semester { get; set; } = 1;
    public string Type {get; set;} = nameof(EAssignmentType.FifteenMinute);
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public int SubjectId { get; set; }
    public int ClassId { get; set; }
}

public class UpdateAssignmentRequest
{
    public string? Title { get; set; }
    //public int? Grade { get; set; }
    //public int? Semester { get; set; } 
    //public string? Type { get; set; } 
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    //public int? SubjectId { get; set; }
    //public int? ClassId { get; set; }
}