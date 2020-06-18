using System;

namespace Kolokwium2.Models
{
    public class PlayerTeam
    {
        public int IdPlayer { get; set; }
        public int IdTeam { get; set; }
        public int NumOnShirt { get; set; }
        public String Comment { get; set; }
        public Player Player { get; set; }
        public Team Team { get; set; }
    }
}