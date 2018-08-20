using System.Collections.Generic;
using System.Threading.Tasks;
using Santex_Football.Database.Models;

namespace Santex_Football.Infrastructure.Repositories
{
    public interface ILeagueRepository
    {
        Task<bool> CheckIfLeagueIsAlreadyImported(string leagueCode);
        Task Save(List<League> leaguesToSave, List<Team> teamsToSave, string leagueCode);
        Task CleanUp();
    }
}
