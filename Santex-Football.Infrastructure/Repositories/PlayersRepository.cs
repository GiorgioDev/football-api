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
            //var teams =  LeagueContext.Leagues.Where(l => l.LeagueCode == leagueCode).Select(t => t.Teams);
            IQueryable<League> teams = LeagueContext.Leagues.Where(l => l.LeagueCode == leagueCode);
            var asd = teams.Select(t => t.Teams);

            var teamIds = new List<int>(); 

            //foreach (var team in teams)
            //{
            //    foreach (var t in team)
            //    {
            //        teamIds.Add(t.TeamId);
            //    }
            //}

            var totalPlayers = LeagueContext.Players.Count(p => teamIds.Contains(p.TeamId));

            return totalPlayers;
        }

        
    }
}
