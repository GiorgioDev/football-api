using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Santex_Football.Application.Entities;

namespace Santex_Football.Application.Services
{
    public class ImportService : IImportService
    {
        private readonly HttpClient _client = new HttpClient();

        private readonly IPersistenceService _persistenceService;

        public ImportService(IPersistenceService persistenceService)
        {
            SetupClient();
            _persistenceService = persistenceService;
        }

        public async Task Import(string leagueCode)
        {
            var leagues = await GetLeagueAsync(leagueCode);
            var teams = await GetTeamsAsync(leagues);
            var players = await GetPlayersAsync(teams);
            
            await _persistenceService.SaveData(leagues, teams, players, leagueCode);
           
        }

        private void SetupClient()
        {
            //TODO move to config file
            _client.BaseAddress = new Uri("http://api.football-data.org/v1/");
            _client.DefaultRequestHeaders.Add("x-auth-token", "3cb2028264a34a9184a98a023a39a0c8 ");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        private async Task<List<CompetitionRootObject>> GetLeagueAsync(string leagueCode)
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



        private async Task<List<TeamRootObject>> GetTeamsAsync(IEnumerable<CompetitionRootObject> leagues)
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

        private async Task<List<PlayerRootObject>> GetPlayersAsync(List<TeamRootObject> teams)
        {
            var players = new List<PlayerRootObject>();

            foreach (var team in teams)
            {
                foreach (var t in team.teams)
                {
                    var link = t._links.players.href;
                    //var link = team._links.teams.href;
                    var response = await _client.GetAsync(link);

                    if (response.IsSuccessStatusCode)
                    {
                        var stringResult = await response.Content.ReadAsStringAsync();
                        var player = JsonConvert.DeserializeObject<PlayerRootObject>(stringResult);
                        players.Add(player);
                    }
                }

            }
            return players;
        }
    }
}