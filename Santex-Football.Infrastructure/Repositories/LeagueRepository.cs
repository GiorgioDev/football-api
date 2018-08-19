using Microsoft.EntityFrameworkCore;
using Santex_Football.Database;
using Santex_Football.Database.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Santex_Football.Infrastructure.Repositories
{
    public class LeagueRepository : BaseRepository, ILeagueRepository
    {

        public LeagueRepository(LeagueContext context) : base(context)
        {
        }

        public async Task<bool> CheckIfLeagueIsAlreadyImported(string leagueCode)
        {
            return await LeagueContext.ImportedLeagues.AnyAsync(x => x.LeagueCodeId == leagueCode);
        }

        public async Task Save(List<League> leaguesToSave, List<Team> teamsToSave, string leagueCode)
        {

            foreach (var league in leaguesToSave)
            {
                await LeagueContext.Leagues.AddAsync(league);

                //Check if Team exists
                var newTeams = RemoveExistingTeams(teamsToSave);

                await LeagueContext.Teams.AddRangeAsync(newTeams);

                //LeagueTeam
                foreach (var team in teamsToSave)
                {
                    var leagueTeams = new List<LeagueTeam>();

                    var leagueTeam = new LeagueTeam
                    {
                        League = league,
                        Team = team
                    };
                    leagueTeams.Add(leagueTeam);
                    await LeagueContext.LeagueTeam.AddAsync(leagueTeam);

                    await LeagueContext.SaveChangesAsync();

                    team.LeagueId = league.LeagueId;
                }
            }

            var importedLeague = new ImportedLeague {LeagueCodeId = leagueCode};

            await LeagueContext.ImportedLeagues.AddAsync(importedLeague);

            await LeagueContext.SaveChangesAsync();
        }

        private IEnumerable<Team> RemoveExistingTeams(List<Team> teamsToSave)
        {
            var newTeams = new List<Team>();
            foreach (var team in teamsToSave)
            {
                var newTeam = LeagueContext.Teams.FirstOrDefault(t => t.Code != team.Code && t.Shortname != team.Shortname);
                if (newTeam != null)
                {
                    newTeams.Add(newTeam);
                }
            }
            return newTeams;
        }
    }
}