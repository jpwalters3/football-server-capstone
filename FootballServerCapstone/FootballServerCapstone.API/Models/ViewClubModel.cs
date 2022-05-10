using System.ComponentModel.DataAnnotations;

namespace FootballServerCapstone.API.Models
{
    public class ViewClubModel
    {
        public int ClubId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Founding Date is required")]
        public DateTime FoundingDate { get; set; }
        [Required(ErrorMessage = "City is required")]
        [StringLength(50, ErrorMessage = "City cannot be longer than 50 characters.")]
        public string City { get; set; }
    }
}
