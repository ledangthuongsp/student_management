public class User
{
    public int Id { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string FullName { get; set; }
    public required string PhoneNumber { get; set; }
    public string DayOfBirth { get; set; }
    public string Gender { get; set; }
    public string AvatarUrl { get; set; }
    public string Role { get; set; }

    public ICollection<SchoolCouncil> SchoolCouncils { get; set; }
    public ICollection<Teacher> Teachers { get; set; }
    public ICollection<Student> Students { get; set; }
    public ICollection<FacultyTeachers> FacultyTeachers { get; set; }
    public ICollection<FacultyStudents> FacultyStudents { get; set; }
    public ICollection<DisciplinedStudents> DisciplinedStudents { get; set; }
    public ICollection<Reward> Rewards { get; set; }
    public ICollection<Assignment> Assignments { get; set; }
    public ICollection<Submit> Submits { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<TeacherSubject> TeacherSubjects { get; set; }
    public ICollection<ScheduleStudents> ScheduleStudents { get; set; }
    public ICollection<Grade> Grades { get; set; }
    public ICollection<Class> Classes { get; set; }
    public ICollection<ClassStudents> ClassStudents { get; set; }
    public ICollection<ClassroomStudents> ClassroomStudents { get; set; }
    public ICollection<Chatroom> Chatrooms { get; set; }
    public ICollection<Notification> Notifications { get; set; }
}
