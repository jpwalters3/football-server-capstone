using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballServerCapstone.Core.DTOs
{
    public class PlayerStatistics
    {
        public int Shots { get; set; }
        public int ShotsOnTarget { get; set; }
        public int Assists { get; set; }
        public int Fouls { get; set; }
        public int Goals { get; set; }
        public int Saves { get; set; }
        public int Passes { get; set; }
        public int CompletedPasses { get; set; }
        public int Dribbles { get; set; }
        public int SuccessfulDribbles { get; set; }
        public int Tackles { get; set; }
        public int SuccessfulTackles { get; set; }
        public int TotalCleanSheet { get; set; }

    }
}
