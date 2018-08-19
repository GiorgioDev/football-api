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
        private readonly MockHttpClient _mockHttpClient;

        public ImportServiceTests()
        {
            _mockHttpClient = new MockHttpClient();
            _persistenceService = new Mock<IPersistenceService>();
        }

        [TestMethod]
        public async Task ShouldInvokeTheApiOk()
        {
            //ARRANGE
            const string leaguecode = "Dummy League Code";
            const string leagueurl = "/v1/competitions";
            var mockClient = _mockHttpClient.GetMockClient(leagueurl);

            var sut = new ImportService(_persistenceService.Object, mockClient);

            //ACT
            await sut.Import(leaguecode);

            //ASSERT
            _persistenceService.Verify(p => p.SaveData(It.IsAny<List<CompetitionRootObject>>(), It.IsAny<List<TeamRootObject>>(), It.IsAny<List<PlayerRootObject>>(), leaguecode), Times.Once);
        }
    }
}