using Kolokwium2.DTOs.Request;
using Kolokwium2.Exceptions;
using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Services
{
    public class SqlServerChampionshipDbService : IChampionshipDbService
    {
        private readonly ChampionshipDbContext _context;

        public SqlServerChampionshipDbService(ChampionshipDbContext context)
        {
            _context = context;
        }
        public async Task AddPlayerToTeam(PlayerRequest req, int id)
        {
            var player = _context.Players
                                 .Where(p => p.FirstName == req.FirstName && p.LastName == req.LastName && p.DateOfBirth == req.DateOfBirth);

            if (player == null)
            {
                throw new PlayerDoesNotExistsException("Player does not exists!");
            }

            if (DateTime.Now.Year - req.DateOfBirth.Year > _context.Teams.FirstOrDefault(p => p.IdTeam == id).MaxAge)
            {
                throw new PlayerAgeToHighException("Too old");
            }

            var playerTeam = new PlayerTeam
            {
                IdTeam = id,
                IdPlayer = _context.Players
                                 .FirstOrDefault(p => p.FirstName == req.FirstName && p.LastName == req.LastName && p.DateOfBirth == req.DateOfBirth).IdPlayer,
                NumOnShirt = req.NumOnShirt,
                Comment = req.Comment
            };

            await _context.PlayerTeams.AddAsync(playerTeam);
        }

        public async Task<Championship> GetChampionshipTeams(int id)
        {
            var championshipTeam = await _context.Championships
                                                 .Include(p => p.ChampionshipTeams)
                                                 .FirstOrDefaultAsync(p => p.IdChampionship == id);

            if (championshipTeam == null)
            {
                throw new ChampionshipTeamDoesNotExistsException($"Championshipteam with id: {id} does not exists");
            }

            championshipTeam.ChampionshipTeams.OrderBy(p => p.Score).ToList();

            return championshipTeam;
        }
    }
}
