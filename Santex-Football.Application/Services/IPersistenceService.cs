using System.Collections.Generic;
using System.Threading.Tasks;
using Santex_Football.Application.Entities;

namespace Santex_Football.Application.Services
{
    public interface IPersistenceService
    {
        Task SaveData(List<CompetitionRootObject> leagues, 
            List<TeamRootObject> teams, 
            List<PlayerRootObject> players,
            string leagueCode);
    }
}