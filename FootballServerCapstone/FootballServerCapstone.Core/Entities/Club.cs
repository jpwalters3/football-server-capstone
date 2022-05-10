using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballServerCapstone.Core.Entities
{
    public class Club
    {
        [Key]
        public int ClubId { get; set; }

        //Properties
        public string Name { get; set; }
        public DateTime FoundingDate { get; set; }
        public string City { get; set; }

        //One to Many
        public List<Loan> Loans { get; set; }
        public List<Match> Matches { get; set; }
        public List<Player> Players { get; set; }
    }
}
