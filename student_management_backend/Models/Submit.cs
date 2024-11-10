public class Submit
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int AssignmentId { get; set; }
    public string Description { get; set; }
    public string AttachFile { get; set; }

    public User Student { get; set; }
    public Assignment Assignment { get; set; }
}
