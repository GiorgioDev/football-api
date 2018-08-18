using System;
using Santex_Football.Application.Entities;
using Santex_Football.Application.Mapper;
using Santex_Football.Database.Models;
using Santex_Football.Infrastructure.Repositories;
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
                MapLeagues(leagues, leaguesToSave);
                MapPlayers(players, playersTosave);
                MapTeams(teams, teamsToSave, playersTosave);

                await _leagueRepository.Save(leaguesToSave, teamsToSave, leagueCode);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void MapPlayers(List<PlayerRootObject> players, List<Player> playersTosave)
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

        private void MapTeams(List<TeamRootObject> teams, List<Team> teamsToSave, List<Player> players)
        {
            foreach (TeamRootObject team in teams)
            {
                foreach (var te in team.teams)
                {
                    var t = _mapper.MapTeam(te, players);
                    teamsToSave.Add(t);
                }

            }
        }

        private void MapLeagues(List<CompetitionRootObject> leagues, List<League> leaguesToSave)
        {
            foreach (var league in leagues)
            {
                var l = _mapper.MapLeague(league);
                leaguesToSave.Add(l);
            }
        }

    }
}