using Microsoft.EntityFrameworkCore;
using Santex_Football.Database;
using Santex_Football.Database.Models;
using System.Collections.Generic;
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

                await LeagueContext.Teams.AddRangeAsync(teamsToSave);

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
    }
}