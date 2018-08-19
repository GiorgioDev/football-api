using System.Collections.Generic;
using System.Threading.Tasks;
using Santex_Football.Application.Entities;

namespace Santex_Football.Application
{
    public interface IFootballDataClient
    {
        Task<List<CompetitionRootObject>> GetCompetitionsAsync(string leagueCode);
        Task<List<TeamRootObject>> GetTeamsAsync(List<CompetitionRootObject> leagues);
        Task<List<PlayerRootObject>> GetPlayersAsync(List<TeamRootObject> teams);
    }
}