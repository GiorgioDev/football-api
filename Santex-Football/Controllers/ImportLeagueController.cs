﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Santex_Football.Application.Exceptions;
using Santex_Football.Application.Services;
using System;
using System.Threading.Tasks;

namespace Santex_Football.Controllers
{
    [Produces("application/json")]
    [Route("import-league")]
    public class ImportLeagueController : Controller
    {

        private readonly ILeagueService _leagueService;

        public ImportLeagueController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(504)]
        // GET: import-league/BL1
        [HttpGet("{leagueCode}")]

        public async Task<IActionResult> Import(string leagueCode)
        {
            try
            {
                await _leagueService.ImportLeague(leagueCode);
            }

            //Already imported 409
            catch (LeagueAlreadyImportedException)
            {
                return Conflict("Already Imported");
            }

            //TODO return a 500 error
            //Server error (Gateway Timeout) 504
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status504GatewayTimeout);
            }

            //Imported ok 201
            return Created("Message", "Successfully imported");
        }


        // GET: import-league/total-players/BL1
        [HttpGet("total-players/{leagueCode}")]
        public async Task<IActionResult> TotalPlayers(string leagueCode)
        {
            int totalPlayers;
            try
            {
                totalPlayers = await _leagueService.TotalPlayersByLeagueCode(leagueCode);
            }
            catch (LeagueNotFoundException)
            {
                return NotFound("League: " + leagueCode + " Not Found");
            }

            return Ok("total: " + totalPlayers);
        }

        [HttpGet("clean-up")]
        public async Task<IActionResult> CleanUp()
        {
            try
            {
                await _leagueService.CleanUpAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("Clean up Failed : "+ ex.Message);
            }

            return Ok("Everything was clean up!");
        }
    }
}