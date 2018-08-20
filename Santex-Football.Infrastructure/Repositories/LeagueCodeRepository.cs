using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Santex_Football.Database;

namespace Santex_Football.Infrastructure.Repositories
{
    public class LeagueCodeRepository : BaseRepository, ILeagueCodeRepository
    {

        public LeagueCodeRepository(LeagueContext context) : base(context)
        {
        }

        public async Task<bool> CheckIfLeagueExists(string leagueCode)
        {
            
                return await LeagueContext.ImportedLeagues.AnyAsync(x => x.LeagueCodeId == leagueCode);
            
        }


    }
}
