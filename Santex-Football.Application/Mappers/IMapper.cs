using System.Collections.Generic;
using Santex_Football.Database.Models;
using Player = Santex_Football.Database.Models.Player;
using Team = Santex_Football.Database.Models.Team;

namespace Santex_Football.Application.Mappers
{
    public interface IMapper
    {
        League MapLeague(Entities.CompetitionRootObject league);
        Team MapTeam(Entities.Team team);
        Player MapPlayer(Entities.Player player, int teamId);
    }
}