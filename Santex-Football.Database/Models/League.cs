using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Santex_Football.Database.Models
{
    public class League
    {
        [Key]
        public int LeagueId { get; set; }
        public string Caption { get; set; }
        public string LeagueCode { get; set; }
        public string Year { get; set; }

        public List<LeagueTeam> LeagueTeams { get; set; } = new List<LeagueTeam>();
        
        public List<Team> Teams { get; set; }= new List<Team>();
    }
}