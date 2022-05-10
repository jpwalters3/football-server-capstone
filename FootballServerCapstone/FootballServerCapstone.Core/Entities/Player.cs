using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FootballServerCapstone.Core.Entities
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public bool IsOnLoan { get; set; }

        //Many to One
        public int ClubId { get; set; }
        public Club Club { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }

        //One to Many
        public List<History> History { get; set; }
        public List<Loan> Loans { get; set; }
        public List<Performance> Performances { get; set; }
    }
}
