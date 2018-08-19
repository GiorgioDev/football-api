using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Santex_Football.Application.Entities;
using Santex_Football.Application.Mappers;
using Santex_Football.Application.Services;
using Santex_Football.Database.Models;
using Santex_Football.Infrastructure.Repositories;
using Team = Santex_Football.Database.Models.Team;

namespace Santex_Football.Application.Tests.Services
{
    [TestClass]
    public class PersistenceServiceTests
    {

        private readonly Mock<ILeagueRepository> _leagueRepoMock;
        private readonly Mock<IMapper> _mapperMock;


        public PersistenceServiceTests()
        {
            _leagueRepoMock = new Mock<ILeagueRepository>();
            _mapperMock = new Mock<IMapper>();
        }
       
        [TestMethod]
        public async Task ShouldSaveDataWithAValidLeagueCode()
        {
            //ARRANGE
            var leagues = new List<CompetitionRootObject>();
            var teams = new List<TeamRootObject>();
            var players = new List<PlayerRootObject>();
            string leaguecode = "Dummy league code";
            
            var sut = new PersistenceService(_mapperMock.Object, _leagueRepoMock.Object);
            
            //ACT
            await sut.SaveData(leagues, teams, players, leaguecode);
            
            //ASSERT
            _leagueRepoMock.Verify(mock => mock.Save(It.IsAny<List<League>>(),
                It.IsAny<List<Team>>(),
                leaguecode), Times.Once());

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task ShouldThrowAnExceptionWhenSaving()
        {
            //ARRANGE
            var leagues = new List<CompetitionRootObject>();
            var teams = new List<TeamRootObject>();
            var players = new List<PlayerRootObject>();
            string leaguecode = "Dummy league code";

            _leagueRepoMock.Setup(x => x.Save(It.IsAny<List<League>>(),
                It.IsAny<List<Team>>(),
                It.IsAny<string>())).Throws<InvalidOperationException>();

            var sut = new PersistenceService(_mapperMock.Object, _leagueRepoMock.Object);

            //ACT
            await sut.SaveData(leagues, teams, players, leaguecode);

            //ASSERT
            

        }
    }
}