using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium2.DTOs.Request;
using Kolokwium2.Exceptions;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamsController : ControllerBase
    {

        private readonly SqlServerChampionshipDbService _dbService;

        public TeamsController(SqlServerChampionshipDbService dbService)
        {
            _dbService = dbService;
        }
    
        [HttpPost("{id:int}")]
        public void AddPlayerToTeam(PlayerRequest req, int id)
        {
            try
            {
                _dbService.AddPlayerToTeam(req, id);
            }
            catch (PlayerDoesNotExistsException exc)
            {

                 NotFound(exc.Message);
            }

        }
    }
}