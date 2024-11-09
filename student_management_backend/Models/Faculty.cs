public class Faculty
{
    public int Id { get; set; }
    public required string FacultyName { get; set; }

    public ICollection<Teacher>? Teachers { get; set; }
    public ICollection<Student>? Students { get; set; }
}
