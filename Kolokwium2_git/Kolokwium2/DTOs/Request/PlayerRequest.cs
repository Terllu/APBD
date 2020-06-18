using System;

namespace Kolokwium2.DTOs.Request
{
    public class PlayerRequest
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NumOnShirt { get; set; }
        public String Comment { get; set; }
    }
}
