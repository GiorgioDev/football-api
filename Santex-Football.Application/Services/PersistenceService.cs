using Santex_Football.Application.Entities;
using Santex_Football.Application.Mappers;
using Santex_Football.Database.Models;
using Santex_Football.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Player = Santex_Football.Database.Models.Player;
using Team = Santex_Football.Database.Models.Team;

namespace Santex_Football.Application.Services
{
    public class PersistenceService : IPersistenceService
    {
        private readonly ILeagueRepository _leagueRepository;
        private readonly IMapper _mapper;

        public PersistenceService(IMapper mapper,
            ILeagueRepository leagueRepository)
        {
            _leagueRepository = leagueRepository;
            _mapper = mapper;
        }
        public async Task SaveData(List<CompetitionRootObject> leagues,
            List<TeamRootObject> teams,
            List<PlayerRootObject> players,
            string leagueCode)
        {

            var leaguesToSave = new List<League>();
            var teamsToSave = new List<Team>();
            var playersTosave = new List<Player>();

            try
            {
                MapTeamPlayers(teamsToSave, playersTosave);

                MapLeagues(leagues, leaguesToSave);

                MapTeams(teams, teamsToSave);

                MapPlayers(players, playersTosave);

                await _leagueRepository.Save(leaguesToSave, teamsToSave, leagueCode);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void MapTeamPlayers(List<Team> teamsToSave, List<Player> playersTosave)
        {
            foreach (var team in teamsToSave)
            {

                foreach (var player in playersTosave)
                {
                    if (player.TeamId == team.TeamId)
                        team.Players.Add(player);
                }
            }
        }

        private void MapPlayers(IEnumerable<PlayerRootObject> players, IList<Player> playersTosave)
        {
            foreach (var player in players)
            {
                foreach (var pl in player.players)
                {
                    var p = _mapper.MapPlayer(pl);
                    playersTosave.Add(p);
                }

            }
        }

        private void MapTeams(IEnumerable<TeamRootObject> teams, IList<Team> teamsToSave)
        {
            foreach (var team in teams)
            {
                foreach (var te in team.teams)
                {
                    var t = _mapper.MapTeam(te);
                    teamsToSave.Add(t);
                }
            }
        }

        private void MapLeagues(IEnumerable<CompetitionRootObject> leagues, IList<League> leaguesToSave)
        {
            foreach (var league in leagues)
            {
                var l = _mapper.MapLeague(league);
                leaguesToSave.Add(l);
            }
        }

    }
}