using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Santex_Football.Database.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int? JerseyNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string ContractUntil { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}