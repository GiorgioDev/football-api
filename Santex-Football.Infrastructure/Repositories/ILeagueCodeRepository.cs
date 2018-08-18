using System.Threading.Tasks;

namespace Santex_Football.Infrastructure.Repositories
{
    public interface ILeagueCodeRepository
    {
        Task<bool> CheckIfLeagueExists(string leagueCode);
    }
}