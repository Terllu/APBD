using Kolokwium2.Exceptions;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        [HttpGet("{id:int}/teams")]
        public async Task<IActionResult> GetChampionshipTeams(int id)
        {
            try
            {
                var result = await _dbService.GetChampionshipTeams(id);
                return Ok(result);
            }
            catch (ChampionshipTeamDoesNotExistsException exc)
            {
                return NotFound(exc.Message);
            }
            
        }
    }
}