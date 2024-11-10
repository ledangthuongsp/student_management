public class Reward
{
    public int Id { get; set; }
    public string RewardName { get; set; }
    public int StudentId { get; set; }

    public User Student { get; set; }
}
