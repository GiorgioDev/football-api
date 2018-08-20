using System.Threading.Tasks;

namespace Santex_Football.Application.Services
{
    public interface ILeagueService
    {
        Task ImportLeague(string leagueCode);
        Task<int> TotalPlayersByLeagueCode(string leagueCode);
        Task CleanUpAsync();
    }
}