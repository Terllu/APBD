using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Models
{
    public class Championship
    {
        public int IdChampionship { get; set; }
        public String OfficialName { get; set; }
        public int Year { get; set; }
        public ICollection<ChampionshipTeam> ChampionshipTeams  { get; set; }
    }
}
