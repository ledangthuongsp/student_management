public class ClassroomStudents
{
    public int ClassroomId { get; set; }
    public int StudentId { get; set; }

    public Classroom Classroom { get; set; }
    public User Student { get; set; }
}
