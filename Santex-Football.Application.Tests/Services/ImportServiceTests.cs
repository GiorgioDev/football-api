using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Santex_Football.Application.Entities;
using Santex_Football.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Santex_Football.Application.Tests.Services
{

    [TestClass]
    public class ImportServiceTests
    {
        private readonly Mock<IPersistenceService> _persistenceService;
        private readonly Mock<IFootballDataClient> _mockHttpClient;

        public ImportServiceTests()
        {
            _mockHttpClient = new Mock<IFootballDataClient>();
            _persistenceService = new Mock<IPersistenceService>();
        }

        [TestMethod]
        public async Task ShouldPersistsDataWithImportData()
        {
            //ARRANGE
            const string leaguecode = "Dummy League Code";
            var sut = new ImportService(_persistenceService.Object, _mockHttpClient.Object);

            //ACT
            await sut.Import(leaguecode);

            //ASSERT
            _persistenceService.Verify(p => p.SaveData(It.IsAny<List<CompetitionRootObject>>(), It.IsAny<List<TeamRootObject>>(), It.IsAny<List<PlayerRootObject>>(), leaguecode), Times.Once);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task ShouldThrowAnExceptionIfClientFails()
        {
            //ARRANGE
            const string leaguecode = "Dummy League Code";
            _mockHttpClient.Setup(c => c.GetCompetitionsAsync(leaguecode)).Throws<InvalidOperationException>();

            var sut = new ImportService(_persistenceService.Object, _mockHttpClient.Object);

            //ACT
            await sut.Import(leaguecode);

            //ASSERT
        }
    }
}