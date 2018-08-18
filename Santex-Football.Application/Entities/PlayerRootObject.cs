using System.Collections.Generic;

namespace Santex_Football.Application.Entities
{
    public class PlayerRootObject
    {
        public Santex_Football.Application.Entities.Links _links { get; set; }
        public int count { get; set; }
        public List<Player> players { get; set; }
    }
}