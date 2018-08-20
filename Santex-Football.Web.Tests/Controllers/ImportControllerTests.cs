using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Santex_Football.Application.Services;
using Santex_Football.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Santex_Football.Application.Exceptions;

namespace Santex_Football.Web.Tests.Controllers
{
    [TestClass]
    public class ImportControllerTests
    {

        private readonly Mock<ILeagueService> _leagueService;

        public ImportControllerTests()
        {
            _leagueService = new Mock<ILeagueService>();
        }


        [TestMethod]
        public async Task ShouldReturnTotalPlayersWithAValidLeagueCode()
        {
            //ARRANGE
            const string leagueCode = "Dummy League code";
            const int totalPlayers = 10;

            _leagueService.Setup(l => l.TotalPlayersByLeagueCode(leagueCode)).Returns(Task.FromResult(totalPlayers));
            var controller = new ImportLeagueController(_leagueService.Object);

            //ACT
            var res = await controller.TotalPlayers(leagueCode);

            //ASSERT
            var okObjectResult = res as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            Assert.AreEqual("total: " +totalPlayers, okObjectResult.Value);
        }


        [TestMethod]
        public async Task ShouldReturnNotFoundIfLeagueDoesNotExistsInvokingTotalPlayers()
        {
            //ARRANGE
            const string leagueCode = "invalid League code";
            const string expectedMessage = "League: " + leagueCode + " Not Found";

            _leagueService.Setup(l => l.TotalPlayersByLeagueCode(leagueCode)).Throws<LeagueNotFoundException>();
            var controller = new ImportLeagueController(_leagueService.Object);

            //ACT
            var res = await controller.TotalPlayers(leagueCode);

            //ASSERT
            var notFoundResult = res as NotFoundObjectResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(expectedMessage, notFoundResult.Value);
        }


        [TestMethod]
        public async Task ShouldReturnCreatedStatusWithAValidLeagueCode()
        {
            //ARRANGE
            const string leagueCode = "Dummy League code";

            
            var controller = new ImportLeagueController(_leagueService.Object);

            //ACT
            var res = await controller.Import(leagueCode);

            //ASSERT
            _leagueService.Verify(l => l.ImportLeague(leagueCode));
            var createdResult = res as CreatedResult;
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("Successfully imported", createdResult.Value);
        }

        [TestMethod]
        public async Task ShouldReturnNotFoundIfLeagueWasNotFound()
        {
            //ARRANGE
            const string leagueCode = " League code not found";
            const string expectedMessage = "League: " + leagueCode + " Not Found";

            _leagueService.Setup(l => l.ImportLeague(leagueCode)).Throws<LeagueNotFoundException>();

            var controller = new ImportLeagueController(_leagueService.Object);

            //ACT
            var res = await controller.Import(leagueCode);

            //ASSERT

            var notFoundResult = res as NotFoundObjectResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(expectedMessage, notFoundResult.Value);
        }


        [TestMethod]
        public async Task ShouldReturnAlreadyImportedIfLeagueWasImported()
        {
            //ARRANGE
            const string leagueCode = " League code Already imported";
            const string expectedMessage = "Already Imported";

            _leagueService.Setup(l => l.ImportLeague(leagueCode)).Throws<LeagueAlreadyImportedException>();

            var controller = new ImportLeagueController(_leagueService.Object);

            //ACT
            var res = await controller.Import(leagueCode);

            //ASSERT

            var conflictObjectResult = res as ConflictObjectResult;
            Assert.IsNotNull(conflictObjectResult);
            Assert.AreEqual(expectedMessage, conflictObjectResult.Value);
        }



        [TestMethod]
        public async Task ShouldReturn504IfImportFails()
        {
            //ARRANGE
            const string leagueCode = " League code Already imported";
            const int expectedResult = StatusCodes.Status504GatewayTimeout;

            _leagueService.Setup(l => l.ImportLeague(leagueCode)).Throws<InvalidOperationException>();

            var controller = new ImportLeagueController(_leagueService.Object);

            //ACT
            var res = await controller.Import(leagueCode);

            //ASSERT

            var errorResult = res as StatusCodeResult;
            Assert.IsNotNull(errorResult);
            Assert.AreEqual(expectedResult, errorResult.StatusCode);
        }
    }
}
