using Santex_Football.Application.Entities;
using Santex_Football.Database.Models;
using System.Collections.Generic;
using Player = Santex_Football.Database.Models.Player;
using Team = Santex_Football.Application.Entities.Team;

namespace Santex_Football.Application.Mapper
{
    public class Mapper : IMapper
    {

        //TODO Move to AutoMapper
        public League MapLeague(CompetitionRootObject league)
        {
            var l = new League();

            if (league != null)
            {
                l.Caption = league.caption;
                l.LeagueCode = league.league;
                l.Year = league.year;
            }
            return l;
        }

        public Database.Models.Team MapTeam(Team team, List<Player> players)
        {
            var teamModel = new Database.Models.Team();

            if (team != null)
            {
                    teamModel.Name = team.name;
                    teamModel.Code = team.code;
                    teamModel.Shortname = team.shortName;

                    if (players != null)
                    {
                        teamModel.Players = new List<Player>();
                        teamModel.Players.AddRange(players);
                    }
                }
            return teamModel;

        }

        public Player MapPlayer(Entities.Player player)
        {
            var playerModel = new Player();
            if (player != null)
            {
                playerModel.JerseyNumber = player.jerseyNumber;
                playerModel.Name = player.name;
                playerModel.Nationality = player.nationality;
                playerModel.Position = player.position;
                playerModel.DateOfBirth = player.dateOfBirth;
                playerModel.ContractUntil = player.contractUntil;
                
            }
            return playerModel;
        }
    }
}