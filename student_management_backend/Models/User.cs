using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    public int Id { get; private set; }  // Có thể giữ public cho khóa chính, nhưng là private setter

    private string Username { get; set; }

    private string Password { get; set; }

    private string FullName { get; set; }

    // Constructor để khởi tạo các thuộc tính bắt buộc
    public User(string username, string password, string fullName)
    {
        Username = username;
        Password = password;
        FullName = fullName;
    }
}