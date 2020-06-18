using Kolokwium2.DTOs.Request;
using Kolokwium2.Exceptions;
using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Kolokwium2.Services
{
    public class SqlServerChampionshipDbService : IChampionshipDbService
    {
        private readonly ChampionshipDbContext _context;

        public SqlServerChampionshipDbService(ChampionshipDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ChampionshipTeam> GetChampionshipTeams(int id)
        {

            var championshipTeam = _context.ChampionshipTeams.Where(p => p.IdChampionship == id)
                                                .Include(p => p.Team)
                                                .OrderBy(p => p.Score).ToList();

            if (championshipTeam == null)
            {
                throw new ChampionshipTeamDoesNotExistsException($"Championshipteam with id: {id} does not exists");
            }
            //championshipTeam.Championship.OrderByDescending(ct => ct.Score).ToList();

            return championshipTeam;
        }

        void IChampionshipDbService.AddPlayerToTeam(PlayerRequest playerRequest, int id)
        {
            var player = _context.Players.AnyAsync(p => p.FirstName == playerRequest.FirstName && p.LastName == playerRequest.LastName && p.DateOfBirth == playerRequest.DateOfBirth);

            if (player == null)
            {
                throw new PlayerDoesNotExistsException("Player does not exists");
            }
        }
    }
}
