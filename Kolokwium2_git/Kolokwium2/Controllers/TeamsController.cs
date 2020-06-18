using Kolokwium2.DTOs.Request;
using Kolokwium2.Exceptions;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
    
        [HttpPost("{id:int}/players")]
        public async Task AddPlayerToTeam(PlayerRequest req, int id)
        {
            try
            {
                await _dbService.AddPlayerToTeam(req, id);
            }
            catch (PlayerDoesNotExistsException exc)
            {
                 NotFound(exc.Message);
            }
            catch (PlayerAgeToHighException exc)
            {
                BadRequest(exc.Message);
            }
        }
    }
}