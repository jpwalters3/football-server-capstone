using FootballServerCapstone.Core.Entities;
namespace FootballServerCapstone.API.Models
{
    public class ClubModel
    {
        public int ClubId { get; set; }
        public string Name { get; set; }
        public DateTime FoundingDate { get; set; }
        public string City { get; set; }
        
    }
}
