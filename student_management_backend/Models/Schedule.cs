public class Schedule
{
    public int Id { get; set; }
    public int ClassroomId { get; set; }
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string DayOfWeek { get; set; }
    public int Duration { get; set; }

    public Classroom Classroom { get; set; }
    public Subject Subject { get; set; }
    public Teacher Teacher { get; set; }
}
