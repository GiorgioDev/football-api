using System.ComponentModel.DataAnnotations;

namespace Santex_Football.Database.Models
{
    public class LeagueCode
    {
        [Key]
        public string LeagueCodeId { get; set; }
        public string Country { get; set; }
        public string LeagueDescription { get; set; }
    }
}