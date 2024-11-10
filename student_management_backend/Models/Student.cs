public class Student
{
    public int Id { get; set; }
    public int ClassId { get; set; }
    public int FacultyId { get; set; }
    public int UserId { get; set; }

    public Class Class { get; set; }
    public Faculty Faculty { get; set; }
    public User User { get; set; }
}
