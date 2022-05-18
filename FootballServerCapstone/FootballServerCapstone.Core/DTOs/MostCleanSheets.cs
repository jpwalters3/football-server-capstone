using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballServerCapstone.Core.DTOs
{
    public class MostCleanSheets
    {
        public int SeasonId { get; set; }
        public string ClubName { get; set; }
        public string PlayerName { get; set; }
        public int TotalCleanSheets { get; set; }

        /*public MostCleanSheets(int seasonId, string clubName, string playerName, int totalCleanSheets)
        {
            SeasonId = seasonId;
            ClubName = clubName;
            PlayerName = playerName;
            TotalCleanSheets = totalCleanSheets;
        }*/
    }
}
