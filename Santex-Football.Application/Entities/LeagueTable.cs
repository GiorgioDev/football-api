namespace Santex_Football.Application.Entities
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class LeagueTable
    {
        [JsonProperty("leagueCaption")]
        public string LeagueCaption { get; set; }

        [JsonProperty("matchday")]
        public long Matchday { get; set; }

        [JsonProperty("standings")]
        public Standings Standings { get; set; }
    }

    public partial class Standings
    {
        [JsonProperty("A")]
        public List<A> A { get; set; }

        [JsonProperty("B")]
        public List<A> B { get; set; }

        [JsonProperty("C")]
        public List<A> C { get; set; }

        [JsonProperty("D")]
        public List<A> D { get; set; }

        [JsonProperty("E")]
        public List<A> E { get; set; }

        [JsonProperty("F")]
        public List<A> F { get; set; }
    }

    public partial class A
    {
        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("rank")]
        public long Rank { get; set; }

        [JsonProperty("team")]
        public string Team { get; set; }

        [JsonProperty("teamId")]
        public long TeamId { get; set; }

        [JsonProperty("playedGames")]
        public long PlayedGames { get; set; }

        [JsonProperty("crestURI")]
        public string CrestUri { get; set; }

        [JsonProperty("points")]
        public long Points { get; set; }

        [JsonProperty("goals")]
        public long Goals { get; set; }

        [JsonProperty("goalsAgainst")]
        public long GoalsAgainst { get; set; }

        [JsonProperty("goalDifference")]
        public long GoalDifference { get; set; }
    }

    public partial class LeagueTable
    {
        public static LeagueTable FromJson(string json) => JsonConvert.DeserializeObject<LeagueTable>(json, Santex_Football.Application.Entities.Converter.Settings);
    }

    
}
