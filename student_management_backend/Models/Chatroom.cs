public class Chatroom
{
    public int Id { get; set; }
    public int ClassId { get; set; }
    public int SenderId { get; set; }
    public string Message { get; set; }
    public string AttachFile { get; set; }

    public Class Class { get; set; }
    public User Sender { get; set; }
}
