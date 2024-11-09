public class Subject
{
    public int Id { get; set; }
    public string SubjectName { get; set; }
    public int FacultyId { get; set; }

    public Faculty Faculty { get; set; }
}
