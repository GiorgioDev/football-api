using System.ComponentModel.DataAnnotations;

namespace Santex_Football.Database.Models
{
    public class ImportedLeague
    {
        [Key]
        public string LeagueCodeId { get; set; }
    }
}