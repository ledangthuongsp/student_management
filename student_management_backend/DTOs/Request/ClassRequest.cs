namespace student_management_backend.DTOs.Request;

public class CreateClassRequest
{
    public string ClassName { get; set; } = default!;
    public int SchoolYearId { get; set; }
    public int Grade { get; set; }
}

public class UpdateClassRequest
{
    public string? ClassName { get; set; }
    //public int? SchoolYearId { get; set; }
    public int? Grade { get; set; }
}

public class GetListClassRequest
{
    public int? StartSchoolYear { get; set; }
    public int? EndSchoolYear { get; set; }
    public int? Grade { get; set; }
}