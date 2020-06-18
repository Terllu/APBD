using Kolokwium2.DTOs.Request;
using Kolokwium2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Services
{
    public interface IChampionshipDbService
    {
        IEnumerable<ChampionshipTeam> GetChampionshipTeams(int id);
        public void AddPlayerToTeam(PlayerRequest playerRequest, int id);
    }
}
