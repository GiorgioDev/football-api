using System.Threading.Tasks;

namespace Santex_Football.Application.Services
{
    public class ImportService : IImportService
    {
        private readonly IFootballDataClient _client;
        private readonly IPersistenceService _persistenceService;

        public ImportService(IPersistenceService persistenceService, IFootballDataClient client)
        {
            _persistenceService = persistenceService;
            _client = client;
        }

        public async Task Import(string leagueCode)
        {
            var leagues = await _client.GetCompetitionsAsync(leagueCode);
            var teams = await _client.GetTeamsAsync(leagues);

            var players = await _client.GetPlayersAsync(teams);

            await _persistenceService.SaveData(leagues, teams, players, leagueCode);
        }
    }
}