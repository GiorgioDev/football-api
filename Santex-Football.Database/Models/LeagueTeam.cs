using System.ComponentModel.DataAnnotations;

namespace Santex_Football.Database.Models
{
    public class LeagueTeam
    {
        public Team Team { get; set; }
        [Key]
        public int TeamId { get; set; }
        public League League { get; set; }
        [Key]
        public int LeagueId { get; set; }
    }
}