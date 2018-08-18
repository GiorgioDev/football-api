using Santex_Football.Database;

namespace Santex_Football.Infrastructure.Repositories
{
    public class BaseRepository
    {

        protected readonly LeagueContext LeagueContext;

        public BaseRepository(LeagueContext context)
        {
            LeagueContext = context;
        }

    }
}