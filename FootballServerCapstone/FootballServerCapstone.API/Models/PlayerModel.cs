namespace FootballServerCapstone.API.Models
{
    public class PlayerModel
    {
        public int PlayerId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public bool IsOnLoan { get; set; }
        public int ClubId { get; set; }
        public int PositionId { get; set; }
    }
}
