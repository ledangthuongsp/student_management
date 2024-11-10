public class Teacher
{
    public int Id { get; set; }
    public string CertificateUrl { get; set; }
    public string Position { get; set; }
    public int FacultyId { get; set; }
    public int UserId { get; set; }

    public Faculty Faculty { get; set; }
    public User User { get; set; }

    // Các phương thức riêng cho Teacher
    public void UploadCertificate() { /* ... */ }

    public void DayOff() { /* ... */ }

    public void CreateAssignment() { /* ... */ }

    public void ReviewAssignment() { /* ... */ }

    public void CreateNotification() { /* ... */ }
}

