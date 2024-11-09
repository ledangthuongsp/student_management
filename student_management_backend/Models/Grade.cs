public class Grade
{
    public int Id { get; set; }
    public double Number { get; set; }
    public int StudentId { get; set; }
    public int TeacherId { get; set; }
    public string Comment { get; set; }

    public Student Student { get; set; }
    public Teacher Teacher { get; set; }
}
