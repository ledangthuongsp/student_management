public class Class
{
    public int Id { get; set; }
    public string ClassName { get; set; }
    public int TeacherId { get; set; }
    public int FacultyId { get; set; }

    public Teacher Teacher { get; set; }
    public Faculty Faculty { get; set; }
}
