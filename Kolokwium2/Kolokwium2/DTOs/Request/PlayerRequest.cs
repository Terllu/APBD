using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.DTOs.Request
{
    public interface PlayerRequest
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NumOnShirt { get; set; }
        public String Comment { get; set; }
        public int IdTeam { get; set; }
    }
}
