public class ScheduleStudents
{
    public int ScheduleId { get; set; }
    public int StudentId { get; set; }

    public Schedule Schedule { get; set; }
    public Student Student { get; set; }
}
