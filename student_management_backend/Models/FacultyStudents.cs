public class FacultyStudents
{
    public int FacultyId { get; set; }
    public int StudentId { get; set; }

    public Faculty Faculty { get; set; }
    public Student Student { get; set; }
}
