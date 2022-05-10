using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballServerCapstone.Core.Entities
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        public string PositionName { get; set; }

        //One to Many
        public List<Player> Players { get; set; }
    }
}
