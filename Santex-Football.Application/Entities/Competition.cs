using System;

namespace Santex_Football.Application.Entities
{
    public class CompetitionRootObject
    {
        public Links _links { get; set; }
        public int id { get; set; }
        public string caption { get; set; }
        public string league { get; set; }
        public string year { get; set; }
        public int currentMatchday { get; set; }
        public int numberOfMatchdays { get; set; }
        public int numberOfTeams { get; set; }
        public int numberOfGames { get; set; }
        public DateTime lastUpdated { get; set; }
    }

    public partial class Self
    {
        public string href { get; set; }
    }

    public partial class Teams
    {
        public string href { get; set; }
    }

    partial class LeagueTable
    {
        public string href { get; set; }
    }

    public partial class Links
    {
        public Self Self { get; set; }
        public Teams teams { get; set; }
        public Fixtures fixtures { get; set; }
        public LeagueTable leagueTable { get; set; }
    }
}