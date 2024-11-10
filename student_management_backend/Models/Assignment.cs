public class Assignment
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int TeacherId { get; set; }
    public string AttachFile { get; set; }
    public int SubjectId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public User Teacher { get; set; }
    public Subject Subject { get; set; }
}
