using Kolokwium2.DTOs.Request;
using Kolokwium2.Models;
using System.Threading.Tasks;

namespace Kolokwium2.Services
{
    public interface IChampionshipDbService
    {
        public Task<Championship> GetChampionshipTeams(int id);
        public Task AddPlayerToTeam(PlayerRequest req, int id);
    }
}
