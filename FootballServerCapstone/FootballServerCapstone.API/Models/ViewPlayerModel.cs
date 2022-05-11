using System.ComponentModel.DataAnnotations;

namespace FootballServerCapstone.API.Models
{
    public class ViewPlayerModel
    {
        public int PlayerId { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Is Active is required")]
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Is On Loan is required")]
        public bool IsOnLoan { get; set; }
        [Required(ErrorMessage = "Club Id is required")]
        public int ClubId { get; set; }
        [Required(ErrorMessage = "Position Id is required")]
        public int PositionId { get; set; }
    }
}
