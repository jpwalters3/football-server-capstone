using System.ComponentModel.DataAnnotations;

namespace FootballServerCapstone.API.Models
{
    public class HistoryModel
    {
        public int HistoryId { get; set; }

        [Required(ErrorMessage = "History entry is required")]
        public string HistoryEntry { get; set; }

        [Required(ErrorMessage = "Associated PlayerId is required")]
        public int PlayerId { get; set; }
    }
}
