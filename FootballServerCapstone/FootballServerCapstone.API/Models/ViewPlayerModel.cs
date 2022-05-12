using System.ComponentModel.DataAnnotations;

namespace FootballServerCapstone.API.Models
{
    public class ViewPlayerModel
    {
        public int PlayerId { get; set; }
        [Required(ErrorMessage = "Player date of birth is required")]
        //[DateOfBirth]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Player first name is required")]
        [StringLength(25, ErrorMessage = "Player first name cannot exceed 25 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Player last name is required")]
        [StringLength(25, ErrorMessage = "Player last name cannot exceed 25 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Player IsActive is required")]
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Player IsOnLoan is required")]
        public bool IsOnLoan { get; set; }
        [Required(ErrorMessage = "Player ClubId is required")]
        public int ClubId { get; set; }
        [Required(ErrorMessage = "Player PositionId is required")]
        public int PositionId { get; set; }
    }
}
