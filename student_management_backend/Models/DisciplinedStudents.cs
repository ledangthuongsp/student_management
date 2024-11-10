public class DisciplinedStudents
{
    public int DisciplinedId { get; set; }
    public int StudentId { get; set; }

    public Disciplined Disciplined { get; set; }
    public User Student { get; set; }
}
