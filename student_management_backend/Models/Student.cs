using System.Security.Claims;

public class Student : User
{
    public int ClassId { get; set; }
    public int FacultyId { get; set; }

    public Class Class { get; set; }
    public Faculty Faculty { get; set; }
}
