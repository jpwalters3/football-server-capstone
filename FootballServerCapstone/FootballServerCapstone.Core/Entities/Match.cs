using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FootballServerCapstone.Core.Entities
{
    public class Match
    {
        [Key]
        public int MatchId { get; set; }

        public int? NumberOfAttendees { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }

        //Many to One
        public int HomeClubId { get; set; }
        public Club HomeClub { get; set; }

        public int VisitingClubId { get; set; }
        public Club VisitingClub { get; set; }

        public int SeasonId { get; set; }
        public Season Season { get; set; }
    }
}
