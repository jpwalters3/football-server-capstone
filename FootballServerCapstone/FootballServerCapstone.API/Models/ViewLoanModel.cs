using System.ComponentModel.DataAnnotations;

namespace FootballServerCapstone.API.Models
{
    public class ViewLoanModel
    {
        public int LoanId { get; set; }
        [Required(ErrorMessage = "Please enter the loan duration in months")]
        public int LoanDuration { get; set; }
        [Required(ErrorMessage = "Please enter the loan start date")]
        public DateTime LoanStart { get; set; }
        [Required(ErrorMessage = "Parent club required")]
        public int ParentClubId { get; set; }
        [Required(ErrorMessage = "Loan club required")]
        public int LoanClubId { get; set; }
        [Required(ErrorMessage = "You need to loan a player at the very least")]
        public int PlayerId { get; set; }
    }
}
