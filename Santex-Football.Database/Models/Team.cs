using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Santex_Football.Database.Models
{
    public class Team
    {
        //Internal id
        [Key]
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Shortname { get; set; }
        public List<Player> Players { get; set; }

        public List<LeagueTeam> LeagueTeams { get; set; } =  new List<LeagueTeam>();

        
        public int LeagueId { get; set; }

        //ID from API 
        [NotMapped]
        public int Id { get; set; }
    }


}