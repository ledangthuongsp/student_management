public class Teacher : User
{
    public int TeacherId { get; set; }

    public string? CertificateUrl { get; set; }

    public string? Position { get; set; }

    public int FacultyId { get; set; }

    // Các phương thức riêng cho Teacher
    public void UploadCertificate() { /* ... */ }

    public void DayOff() { /* ... */ }

    public void CreateAssignment() { /* ... */ }

    public void ReviewAssignment() { /* ... */ }

    public void CreateNotification() { /* ... */ }
}