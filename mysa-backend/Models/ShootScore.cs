namespace mysa_backend.Models
{
    public class ShootScore
    {
        public string ShootId { get; set; }
        public ShooterScore[] Scores { get; set; }
    }

    public class ShooterScore
    {
        public string ShooterId { get; set; }
        public bool[] Score { get; set; }
    }
}
