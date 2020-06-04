using System;
using System.ComponentModel.DataAnnotations;

namespace Cw11.DTOs.Requests
{
    public class AddDoctorRequest
    {
        [Required(ErrorMessage = "Musisz podać imię!")]
        [MaxLength(10)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Musisz podać nazwisko!")]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Musisz podać E-mail!")]
        public string Email { get; set; }
    }
}
