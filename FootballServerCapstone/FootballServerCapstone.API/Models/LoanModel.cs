namespace FootballServerCapstone.API.Models
{
    public class LoanModel
    {
        public int LoanId { get; set; }

        public int LoanDuration { get; set; }
        public DateTime LoanStart { get; set; }
        public int ParentClubId { get; set; }
        public int LoanClubId { get; set; }
        public int PlayerId { get; set; }
    }
}
