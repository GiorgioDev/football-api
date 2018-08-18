namespace Santex_Football.Infrastructure.Repositories
{
    public interface IPlayersRepository
    {
        int GetTotalPlayersByLeagueCode(string leagueCode);
    }
}