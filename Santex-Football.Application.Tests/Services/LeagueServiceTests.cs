using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Santex_Football.Application.Exceptions;
using Santex_Football.Application.Services;
using Santex_Football.Infrastructure.Repositories;

namespace Santex_Football.Application.Tests.Services
{
    [TestClass]
    public class LeagueServiceTests
    {

        private readonly Mock<ILeagueCodeRepository> _leagueCodeRepository;
        private readonly Mock<ILeagueRepository> _leagueRepository;
        private readonly Mock<IPlayersRepository> _playersRepository;
        private readonly Mock<IImportService> _importService;

        public LeagueServiceTests()
        {
            _leagueCodeRepository = new Mock<ILeagueCodeRepository>();
            _leagueRepository = new Mock<ILeagueRepository>() ;
            _playersRepository = new Mock<IPlayersRepository>();
            _importService = new Mock<IImportService>() ;
        }

        [TestMethod]
        public async Task ShouldReturnTotalPlayerWithAvalidLeagueCode()
        {
            //ARRANGE
            const string leaguecode = "Dummy league code";
            const int totalplayers = 10;


            _leagueCodeRepository.Setup(l => l.CheckIfLeagueExists(leaguecode)).Returns(Task.FromResult(true));

            _playersRepository.Setup(p => p.GetTotalPlayersByLeagueCode(leaguecode))
                .Returns(totalplayers);

            var sut = new LeagueService(_leagueCodeRepository.Object,
                _leagueRepository.Object,
                _playersRepository.Object,
                _importService.Object);

            //ACT
            var res = await sut.TotalPlayersByLeagueCode(leaguecode);

            //ASSERT
            Assert.AreEqual(res, totalplayers);
        }



        [TestMethod]
        [ExpectedException(typeof(LeagueNotFoundException))]
        public async Task ShouldThrownAnExceptionIfLeagueCodeIsNotValidWhenGettingTotalPlayers()
        {
            //ARRANGE
            const string leaguecode = "not valid League code";
            
            var sut = new LeagueService(_leagueCodeRepository.Object,
                _leagueRepository.Object,
                _playersRepository.Object,
                _importService.Object);

            //ACT
          await sut.TotalPlayersByLeagueCode(leaguecode);

            //ASSERT
        }



        [TestMethod]
        [ExpectedException(typeof(LeagueAlreadyImportedException))]
        public async Task ShouldThrownAnExceptionIfLeagueIsAlreadyImported()
        {
            //ARRANGE
            const string leaguecode = "Already Imported League code";

            _leagueCodeRepository.Setup(l => l.CheckIfLeagueExists(leaguecode)).Returns(Task.FromResult(true));
            _leagueRepository.Setup(l => l.CheckIfLeagueIsAlreadyImported(leaguecode)).Returns(Task.FromResult(true));



            var sut = new LeagueService(_leagueCodeRepository.Object,
                _leagueRepository.Object,
                _playersRepository.Object,
                _importService.Object);

            //ACT
            await sut.ImportLeague(leaguecode);

            //ASSERT
        }


        [TestMethod]
        public async Task ShouldInvokeLeagueServiceWithAValidLeagueCode()
        {
            //ARRANGE
            const string leaguecode = "Dummy league code";
            
            _leagueCodeRepository.Setup(l => l.CheckIfLeagueExists(leaguecode)).Returns(Task.FromResult(true));
            _leagueRepository.Setup(l => l.CheckIfLeagueIsAlreadyImported(leaguecode)).Returns(Task.FromResult(false));
            

            var sut = new LeagueService(_leagueCodeRepository.Object,
                _leagueRepository.Object,
                _playersRepository.Object,
                _importService.Object);

            

            //ACT
            await sut.ImportLeague(leaguecode);

            //ASSERT
            _importService.Verify(i => i.Import(leaguecode), Times.Once);
        }
    }
}
