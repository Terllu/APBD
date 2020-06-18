using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium2.Exceptions;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers
{
    [Route("api/championship")]
    [ApiController]
    public class ChampionshipController : ControllerBase
    {
        private readonly SqlServerChampionshipDbService _dbService;

        public ChampionshipController(SqlServerChampionshipDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetChampionshipTeams(int id)
        {
            try
            {
                var result =  _dbService.GetChampionshipTeams(id);
                return Ok(result);
            }
            catch (ChampionshipTeamDoesNotExistsException exc)
            {

                return NotFound(exc.Message);
            }
            
        }
    }
}