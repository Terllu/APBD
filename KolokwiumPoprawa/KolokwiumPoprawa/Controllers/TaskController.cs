using KolokwiumPoprawa.Exceptions;
using KolokwiumPoprawa.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace KolokwiumPoprawa.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {

        private readonly IDbService _dbService;
        public IConfiguration Configuration { get; set; }
        public TaskController(IConfiguration configuration, IDbService dbService)
        {
            _dbService = dbService;
            Configuration = configuration;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetTeamMember(int id)
        {
            try
            {
                return Ok(_dbService.GetTeamMember(id));
            }
            catch (MemberDoesNotExists exc)
            {
                return NotFound(exc.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProject(int id)
        {
            try
            {
                return Ok(_dbService.DeleteProject(id));
            }
            catch (ProjectDoesNotExists exc)
            {

                return NotFound(exc.Message);
            }

        }
    }
}
