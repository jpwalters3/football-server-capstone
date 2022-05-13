using System.ComponentModel.DataAnnotations;

namespace FootballServerCapstone.API.Models
{
    public class ViewMatchModel
    {
        public int MatchId { get; set; }
        [Required(ErrorMessage = "Match Date is required")]
        public DateTime MatchDate { get; set; } 
        public int? NumberOfAttendees { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        [Required(ErrorMessage = "Home Team is required")]
        public int HomeClubId { get; set; }
        [Required(ErrorMessage = "Away Team is required")]
        public int VisitingClubId { get; set; }
        [Required(ErrorMessage = "Season is required")]
        public int SeasonId { get; set; } 
    }
}
