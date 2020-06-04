using System;
using System.ComponentModel.DataAnnotations;

namespace Cw10.DTOs.Requests
{
    public class EnrollStudentRequest
    {
        [Required(ErrorMessage = "Musisz podać Index!")]
        [RegularExpression("^s[0-9]+$")]
        public string IndexNumber { get; set; }

        [Required(ErrorMessage ="Musisz podać imię!")]
        [MaxLength(10)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Musisz podać nazwisko!")]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Musisz podać date urodzenia!")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Musisz podać studia!")]
        public string Studies { get; set; }
    }
}
