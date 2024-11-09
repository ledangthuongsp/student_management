public class Classroom
{
    public int Id { get; set; }
    public string RoomCode { get; set; }
    public int SubjectId { get; set; }
    public int ScheduleId { get; set; }
    public int NumberOfStudent { get; set; }

    public Subject Subject { get; set; }
    public Schedule Schedule { get; set; }
}
