using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FootballServerCapstone.Core.Entities
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }

        public int LoanDuration { get; set; }
        public DateTime LoanStart { get; set; }

        //Many to One
        public int ParentClubId { get; set; }
        public Club ParentClub { get; set; }

        public int LoanClubId { get; set; }
        public Club LoanClub { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Loan loan &&
                LoanId == loan.LoanId &&
                LoanDuration == loan.LoanDuration &&
                ParentClubId == loan.ParentClubId &&
                LoanClubId == loan.LoanClubId &&
                PlayerId == loan.PlayerId;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(LoanId, LoanDuration, ParentClubId, LoanClubId, PlayerId);
        }
    }
}
