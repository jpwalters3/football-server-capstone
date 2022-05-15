namespace FootballServerCapstone.API.Models
{
    public class MatchModel
    {
        public int MatchId { get; set; }
        public DateTime MatchDate { get; set; }
        public int? NumberOfAttendees { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public int HomeClubId { get; set; }
        public int VisitingClubId { get; set; }
        public int SeasonId { get; set; }
    }
}
