using System.Collections.Generic;
using System.Linq;
using Santex_Football.Database;
using Santex_Football.Database.Models;

namespace Santex_Football.Infrastructure.Repositories
{
    public class PlayersRepository : BaseRepository, IPlayersRepository
    {
        public PlayersRepository(LeagueContext context) : base(context)
        {
        }
        public int GetTotalPlayersByLeagueCode(string leagueCode)
        {
            int total = 0;

            var leagues =  LeagueContext.Leagues.Where(l => l.LeagueCode == leagueCode);

            var teams = leagues.Select(t => t.Teams);

            var players = teams.Select(p => p.Select(x => x.Players));

            foreach (var player in players)
            {
                total = player.Aggregate(total, (current, p) => current + p.Count());
            }

            return total;
        }
    }
}
