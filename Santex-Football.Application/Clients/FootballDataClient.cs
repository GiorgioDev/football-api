using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Santex_Football.Application.Entities;

namespace Santex_Football.Application.Clients
{
    public class FootballDataClient : IFootballDataClient
    {
        private readonly HttpClient _client;

        public FootballDataClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<CompetitionRootObject>> GetCompetitionsAsync(string leagueCode)
        {

            var leagues = new List<CompetitionRootObject>();

            var response = await _client.GetAsync("competitions");

            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                var competitions = JsonConvert.DeserializeObject<List<CompetitionRootObject>>(stringResult);

                foreach (var competition in competitions)
                {
                    if (competition.league == leagueCode)
                    {
                        leagues.Add(competition);
                    }
                }
                return leagues;
            }
            return leagues;
        }

        public async Task<List<TeamRootObject>> GetTeamsAsync(List<CompetitionRootObject> leagues)
        {
            var teams = new List<TeamRootObject>();

            foreach (var league in leagues)
            {
                var link = $"competitions/{league.id}/teams";
                var response = await _client.GetAsync(link);

                if (response.IsSuccessStatusCode)
                {
                    var stringResult = await response.Content.ReadAsStringAsync();
                    var team = JsonConvert.DeserializeObject<TeamRootObject>(stringResult);
                    teams.Add(team);
                }
            }
            return teams;
        }

        public async Task<List<PlayerRootObject>> GetPlayersAsync(List<TeamRootObject> teams)
        {
            var players = new List<PlayerRootObject>();

            foreach (var team in teams)
            {
                foreach (var t in team.teams)
                {

                    var link = t._links.players.href;
                    var response = await _client.GetAsync(link);

                    if (response.IsSuccessStatusCode)
                    {
                        var stringResult = await response.Content.ReadAsStringAsync();
                        var player = JsonConvert.DeserializeObject<PlayerRootObject>(stringResult);

                        //Relate Player with Team
                        player.TeamId = MapTeamId(t._links.self.href);
                        t.TeamId = MapTeamId(t._links.self.href);

                        players.Add(player);
                    }
                }
            }
            return players;
        }

        private int MapTeamId(string url)
        {
            var parseOk = int.TryParse(url.Split('/')[5], out var id);
            return parseOk ? id : 0;
        }

    }
}
