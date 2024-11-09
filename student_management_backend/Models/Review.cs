public class Review
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int SubmitId { get; set; }
    public int AssignmentId { get; set; }
    public int TeacherId { get; set; }

    public Submit Submit { get; set; }
    public Assignment Assignment { get; set; }
    public Teacher Teacher { get; set; }
}
