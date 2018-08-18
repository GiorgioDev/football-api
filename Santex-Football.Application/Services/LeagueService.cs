using System;
using System.Threading.Tasks;
using Santex_Football.Application.Exceptions;
using Santex_Football.Infrastructure.Repositories;

namespace Santex_Football.Application.Services
{
    public class LeagueService : ILeagueService
    {

        private readonly ILeagueCodeRepository _leagueCodeRepository;
        private readonly ILeagueRepository _leagueRepository;
        private readonly IPlayersRepository _playersRepository;
        private readonly IImportService _importService;

        public LeagueService(ILeagueCodeRepository leagueCodeRepository, 
            ILeagueRepository leagueRepository, 
            IPlayersRepository playersRepository, 
            IImportService importService)
        {
            _leagueCodeRepository = leagueCodeRepository;
            _leagueRepository = leagueRepository;
            _playersRepository = playersRepository;
            _importService = importService;
        }

        public async Task ImportLeague(string leagueCode)
        {
            try
            {
                await CheckIfLeagueExists(leagueCode);

                var alreadyImportedLeague = await _leagueRepository.CheckIfLeagueIsAlreadyImported(leagueCode);

                if (alreadyImportedLeague)
                    throw new LeagueAlreadyImportedException();

                await _importService.Import(leagueCode);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        

        public async Task<int> TotalPlayersByLeagueCode(string leagueCode)
        {
            try
            {
                await CheckIfLeagueExists(leagueCode);

                return _playersRepository.GetTotalPlayersByLeagueCode(leagueCode);
            }
            catch (LeagueNotFoundException e)
            {
                throw e;
            }
        }

        private async Task CheckIfLeagueExists(string leagueCode)
        {
            var leagueExists = await _leagueCodeRepository.CheckIfLeagueExists(leagueCode);

            if (!leagueExists)
                throw new LeagueNotFoundException();
        }
    }
} 