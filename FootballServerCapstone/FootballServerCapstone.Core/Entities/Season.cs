using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FootballServerCapstone.Core.Entities
{
    public class Season
    {
        [Key]
        public int SeasonId { get; set; }

        public string Year { get; set; }

        //One to Many
        public List<Match> Matches { get; set; }
    }
}
