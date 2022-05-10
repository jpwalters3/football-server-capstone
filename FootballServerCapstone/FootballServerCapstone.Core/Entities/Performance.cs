using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FootballServerCapstone.Core.Entities
{
    public class Performance
    {
        //Primary Keys
        public int MatchId { get; set; }
        public int PlayerId { get; set; }

        public int ShotsOnTarget { get; set; }
        public int Fouls { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int Saves { get; set; }
        public int Shots { get; set; }
        public int Passes { get; set; }
        public int PassesCompleted { get; set; }
        public int Dribbles { get; set; }
        public int DribblesSucceeded { get; set; }
        public int Tackles { get; set; }
        public int TacklesSucceeded { get; set; }
        public bool CleanSheet { get; set; }

        //Many to One
        public Match Match { get; set; }
        public Player Player { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
