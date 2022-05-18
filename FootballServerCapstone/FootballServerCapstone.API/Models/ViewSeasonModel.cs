using System.ComponentModel.DataAnnotations;

namespace FootballServerCapstone.API.Models
{
    public class ViewSeasonModel
    {
        public int SeasonId { get; set; }
        [Required(ErrorMessage = "Season Year is required")]
        [StringLength(20, ErrorMessage = "Year cannot be longer than 20 characters.")]
        public string Year { get; set; }
        public bool IsActive { get; set; }
    }
} 
